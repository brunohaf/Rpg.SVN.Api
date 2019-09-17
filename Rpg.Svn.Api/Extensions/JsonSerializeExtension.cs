using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Extensions
{
    public class JsonSerializeExtension
    {
        public IEnumerable<Spell> GetSpellListFromJson(string spellJson)
        {
            var test = JsonConvert.DeserializeObject<List<Spell>>(spellJson);
            return null;
        }
    }
}
