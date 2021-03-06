﻿using System;
using Blip.HttpClient.Extensions;
using Lime.Protocol.Serialization.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Api.Middleware;
using Rpg.Svn.Api.Models;
using Rpg.Svn.Api.Services;
using Rpg.Svn.Thirdparty.Factories;
using Rpg.Svn.Thirdparty.Services;
using Serilog;
using Serilog.Exceptions;
using Swashbuckle.AspNetCore.Swagger;

namespace Rpg.Svn.Api
{
    public class Startup
    {
        private const string SWAGGERFILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
        private const string SETTINGS_SECTION = "Settings";
        private const string APPLICATION_KEY = "Application";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Parsing appsettings into class
            var settings = Configuration.GetSection(SETTINGS_SECTION).Get<MySettings>();

            // Adds BLiP's Json Serializer to use on BLiP's Builder
            services.AddMvc().AddJsonOptions(options =>
            {
                foreach (var settingsConverter in JsonNetSerializer.Settings.Converters)
                {
                    options.SerializerSettings.Converters.Add(settingsConverter);
                }
            });

            // Dependency injection
            services.AddSingleton(settings);
            services.AddSingleton(settings.BlipBotSettings);

            // Adding PartyInfo Json
            var partyinfo = FileReaderService.ReadJson<PartyInfo>("partyinfo.json");
            services.AddSingleton(partyinfo);

            //SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .ReadFrom.Configuration(Configuration)
                     .Enrich.WithMachineName()
                     .Enrich.WithProperty(APPLICATION_KEY, Constants.PROJECT_NAME)
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());

            // BLiP services registration
            services.DefaultRegister(settings.BlipBotSettings.Authorization);

            // Project specific Services
            services.AddSingleton<IPartyService, PartyService>();
            services.AddSingleton<ISpellService, SpellService>();
            services.AddSingleton<IMonsterService, MonsterService>();
            services.AddSingleton<IMonsterFactory, MonsterFactory>();
            services.AddSingleton<IOpen5eService>(provider =>
            {
                var logger = provider.GetService<ILogger>();
                // Partner API
                var clientBuilder = new RestingLogger.Builders.LoggedRestClientBuilder();
                var httpClient = clientBuilder.BuildLoggedClient<IOpen5eService>(settings.ThirdPartySettings.Open5eBaseUrl, logger);
                return httpClient;
            });

            services.AddSingleton<IWebDriver>(webDriver =>
            {
                var service = ChromeDriverService.CreateDefaultService(driverPath: AppDomain.CurrentDomain.BaseDirectory);
                service.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                //options.AddArguments("headless");
                options.Proxy = null;
                return new ChromeDriver(service, options);
            });


            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new Info { Title = Constants.PROJECT_NAME, Version = API_VERSION });
                //var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + Constants.XML_EXTENSION;
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use Error Handling Middleware to enable easy automated try-catch on Controller Actions
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint(SWAGGERFILE_PATH, Constants.PROJECT_NAME + API_VERSION);
            });

            app.UseMvc();
        }
    }
}
