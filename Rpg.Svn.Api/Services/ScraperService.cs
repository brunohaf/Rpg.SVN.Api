using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rpg.Svn.Api.Extensions;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Services
{
    public class ScraperService : IScraperService
    {

        private IWebDriver _webDriver;
        public void Init()
        {
            var service = ChromeDriverService.CreateDefaultService(driverPath: AppDomain.CurrentDomain.BaseDirectory);
            service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArguments("headless");
            options.Proxy = null;
            _webDriver = new ChromeDriver(service,options);
            _webDriver.Navigate().GoToUrl("https://www.dndbeyond.com/monsters/tarrasque");
           
            Test();
        }
        public void Test()
        {/*
            var tibitElementList = _webDriver.GetTidbitList();
            var dict = new Dictionary<string, string>();

            foreach (var tidbitElement in tibitElementList)
            {
                var tidbit = tidbitElement.GetTidbitKeyAndValue();
                dict.Add(tidbit.Key, tidbit.Value);
            }
            var image = _webDriver.FindElements(By.XPath("//div/a/img[@class='monster-image']")).FirstOrDefault();
            dict.Add("imageUrl", image.GetAttribute("src"));
            
            var tost = dict;
            */
         //var monsterElement = _webDriver.FindElement(By.XPath("//div[@class='mon-stat-block']"));
         //var monsterHeader = monsterElement.FindElement(By.XPath("//div/div[@class='mon-stat-block__header']"));
            var monsterElement = new MonsterFactory(_webDriver.FindElement(By.XPath("//div[@class='mon-stat-block']")));
            var monster = monsterElement.GenerateMonster();
            if (monster is null)
            {

            }
        }

    }

}
