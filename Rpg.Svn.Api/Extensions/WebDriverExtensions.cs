using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Rpg.Svn.Api.Extensions
{

    public static class WebScrappertExtensions
    {
        private const string TIDBIT_LABEL = "mon-stat-block__tidbit-label";
        private const string TIDBIT_DATA = "mon-stat-block__tidbit-data";
        private const string TIDBIT_BLOCK = "mon-stat-block__tidbit";
        private const string MONSTER_NAME_XPATH = "//div/a[@class='mon-stat-block__name-link']";

        public static IWebElement GetElementByClassName(this IWebElement webElement, string label) => webElement.FindElement(By.ClassName(label));
        public static List<IWebElement> GetElementsListByClass(this IWebDriver webDriver, string label) => webDriver.FindElements(By.ClassName(label)).ToList();

        public static string GetMonsterName(this IWebElement monsterElement) => monsterElement.FindElement(By.XPath(MONSTER_NAME_XPATH)).Text;
    }
}
