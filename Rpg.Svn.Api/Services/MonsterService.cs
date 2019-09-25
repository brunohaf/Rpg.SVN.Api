using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RestEase;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Thirdparty.Facades;
using Rpg.Svn.Thirdparty.Services;

namespace Rpg.Svn.Api.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly IOpen5eService _api;
        private const int SPELL_FIRST_PAGE = 1;
        private const int SPELL_LAST_PAGE = 7;

        public MonsterService(IOpen5eService apiOpen5e)
        {
            _api = apiOpen5e;
        }
        public async Task<IEnumerable<Monster>> GetMonsterListAsync()
        {
            try
            {
                var fullMonsterList = new List<Monster>();
                foreach (var page in Enumerable.Range(SPELL_FIRST_PAGE, SPELL_LAST_PAGE).ToList())
                {
                    var pagedMonsterList = await _api.GetMonstersAsync(page);
                    fullMonsterList = fullMonsterList.Concat(pagedMonsterList.MonsterList).ToList();
                }
                return fullMonsterList;
            }
            catch (ApiException e)
            {
                return null;
            }
        }

        public async Task<Monster> GetMonsterbyNameAsync(string monsterName)
        {
            var fullList = await GetMonsterListAsync();
            return fullList.ToList().Where(s => s.NameIsMatch(monsterName)).FirstOrDefault();
        }
    }
}
