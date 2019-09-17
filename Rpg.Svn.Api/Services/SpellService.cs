using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestEase;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Thirdparty.Facades;
using Rpg.Svn.Thirdparty.Services;

namespace Rpg.Svn.Api.Services
{
    public class SpellService : ISpellService
    {
        private readonly IOpen5eService _api;
        private const int SPELL_FIRST_PAGE = 1;
        private const int SPELL_LAST_PAGE = 7;

        public SpellService(IOpen5eService apiOpen5e)
        {
            _api = apiOpen5e;
        }
        public async Task<IEnumerable<Spell>> GetSpellListAsync()
        {
            try
            {
                var fullSpellList = new List<Spell>();
                foreach (var page in Enumerable.Range(SPELL_FIRST_PAGE, SPELL_LAST_PAGE).ToList())
                {
                    var pagedSpellList = await _api.GetSpellsAsync(page);
                    fullSpellList = fullSpellList.Concat(pagedSpellList.SpellList).ToList();
                }
                return fullSpellList;
            }
            catch (ApiException e)
            {
                return null;
            }
        }

        public async Task<Spell> GetSpellbyNameAsync(string spellName)
        {
            var fullList = await GetSpellListAsync();
            return fullList.ToList().Where(s => s.NameIsMatch(spellName)).FirstOrDefault();
        }
    }
}
