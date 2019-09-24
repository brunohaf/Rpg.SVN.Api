using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rpg.Svn.Api.Interfaces;

namespace Rpg.Svn.Api.Services
{
    public class ScraperService : IScraperService
    {

        private IWebDriver _webDriver;
        public void Init()
        {
            var service = ChromeDriverService.CreateDefaultService(driverPath: @"C:\Users\brunof\source\repos\brunohaf\Rpg.SVN.Api\Rpg.Svn.Thirdparty\");
            service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArguments("headless");
            _webDriver = new ChromeDriver(service,options);
            _webDriver.Navigate().GoToUrl("https://www.dndbeyond.com/monsters/red-dragon-wyrmling");
            
            _webDriver.Manage().Window.Maximize();
            Test();
        }
        public void Test()
        {
            var thatList = _webDriver.FindElements(By.ClassName("mon-stat-block__tidbit")).ToList();
            var dict = new Dictionary<string, string>();
            foreach (var label in thatList)
            {
                dict.Add(label.FindElement(By.ClassName("mon-stat-block__tidbit-label")).Text, label.FindElement(By.ClassName("mon-stat-block__tidbit-data")).Text);
            }

            var tost = dict;

        }

    }
}
