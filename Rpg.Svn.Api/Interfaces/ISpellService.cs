using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Interfaces
{
    public interface ISpellService
    {
        Task<IEnumerable<Spell>> GetSpellListAsync();
        Task<Spell> GetSpellbyNameAsync(string spellName);
    }
}
