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

        public SpellService(IOpen5eService apiOpen5e)
        {
            _api = apiOpen5e;
        }
        public async Task<IEnumerable<Spell>> GetSpellListAsync(string page)
        {
            try
            {
                var teste = await _api.GetSpellsAsync(page);
                return teste.SpellList;
            }
            catch(ApiException e)
            {
                return null;
            }         
            catch(JsonException e)
            {
                return null;
            }
        } 
    }
}
