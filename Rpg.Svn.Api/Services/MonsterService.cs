using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RestEase;
using Rpg.Svn.Api.Extensions;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Api.Models;
using Rpg.Svn.Thirdparty.Models;
using Rpg.Svn.Thirdparty.Services;

namespace Rpg.Svn.Api.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly IWebDriver _webDriver;
        private readonly IMonsterFactory _monsterFactory;
        private const int FIRST_PAGE = 1;
        private const int PAGE_SIZE = 5;
        private const string MONSTER_SEARCH_BASE_URL = "https://www.dndbeyond.com/search?q=";
        private const string MONSTER_SEARCH_QUERY = "&f=monsters&c=monsters";
        private const string SEARCH_ELEMENT_XPATH = "//div/a[@class='link']";


        public MonsterService(IWebDriver webDriver, IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
            _webDriver = webDriver;
        }
        public async Task<IEnumerable<MonsterResponse>> GetMonsterAspirantsAsync(string monsterName)
        {
            try
            {
                _webDriver.GoToUrl(MONSTER_SEARCH_BASE_URL + monsterName + MONSTER_SEARCH_QUERY);
                var searchElement = _webDriver.GetElementsListByXpath(SEARCH_ELEMENT_XPATH).ToList();
                var monsterList = new List<MonsterResponse>();
                var perPageCounter = default(int);
                var localMonsterDict = new Dictionary<int, string>();
                var page = FIRST_PAGE;

                foreach (var element in searchElement)
                    if (perPageCounter < PAGE_SIZE)
                    {
                        if (!string.IsNullOrEmpty(element.Text))
                        {
                            localMonsterDict.Add(perPageCounter, element.Text);
                        }
                        perPageCounter++;
                    }
                    else
                    {
                        perPageCounter = default(int);

                        monsterList.Add(new MonsterResponse
                        {
                            Page = page,
                            Values = new Dictionary<int, string>(localMonsterDict)
                        });
                        localMonsterDict.Clear();
                        page++;
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
