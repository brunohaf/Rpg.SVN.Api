using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IMonsterService
    {
        Task<Monster> GetMonsterbyNameAsync(string monsterName);
        Task<IEnumerable<Monsterll>> GetMonsterListAsync();
    }
}
