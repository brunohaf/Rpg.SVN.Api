using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RestEase;
using Rpg.Svn.Api.Extensions;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Thirdparty.Models;
using Rpg.Svn.Thirdparty.Services;

namespace Rpg.Svn.Api.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly IOpen5eService _api;
        private readonly IWebDriver _webDriver;
        private const int SPELL_FIRST_PAGE = 1;
        private const int SPELL_LAST_PAGE = 7;
        private const string MONSTER_SEARCH_BASE_URL = "https://www.dndbeyond.com/search?q=";
        private readonly IMonsterFactory _monsterFactory;
        private const string MONSTER_SEARCH_QUERY = "&f=monsters&c=monsters";

        public MonsterService(IOpen5eService apiOpen5e, IWebDriver webDriver, IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
            _api = apiOpen5e;
            _webDriver = webDriver;
        }
        public async Task<Dictionary<int, string>> GetMonsterAspirantsAsync(string monsterName)
        {
            try
            {
                _webDriver.GoToUrl(MONSTER_SEARCH_BASE_URL + monsterName + MONSTER_SEARCH_QUERY);
                var searchElement = _webDriver.GetElementsListByXpath("//div/a[@class='link']").ToList();
                var monsterList = new Dictionary<int, string>();
                foreach (var element in searchElement)
                    if (!string.IsNullOrEmpty(element.Text))
                    {
                        monsterList.Add(searchElement.IndexOf(element), element.Text);
                    }
                return monsterList;
            }
            catch (ApiException e)
            {
                return null;
            }
        }

        public Monster GetMonsterbyName(string monsterName)
        {
            return _monsterFactory.GenerateMonster(monsterName);
        }


    }
}
