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

        public static IWebElement GetElementByClassName(this IWebElement webElement, string label) {
            var response = default(IWebElement);
            try
            {
                response = webElement.FindElement(By.ClassName(label));
            }
            catch(Exception e)
            {
                return null;
            }
            return response;
        }

        public static IWebElement GetElementByXpath(this IWebElement webElement, string label)
        {
            var response = default(IWebElement);
            try
            {
                response = webElement.FindElement(By.XPath(label));
            }
            catch (Exception e)
            {
                return null;
            }
            return response;
        }

        public static List<IWebElement> GetElementsListByClass(this IWebDriver webDriver, string label) => webDriver.FindElements(By.ClassName(label)).ToList();
        public static List<IWebElement> GetElementsListByClass(this IWebElement webElement, string label) => webElement.FindElements(By.ClassName(label)).ToList();
        public static List<IWebElement> GetElementsListByXpath(this IWebElement webDriver, string label) => webDriver.FindElements(By.XPath(label)).ToList();

    }
}
