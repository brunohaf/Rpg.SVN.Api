using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IMonsterService
    {
        Monster GetMonsterbyName(string monsterName);
        Task<IEnumerable<string>> GetMonsterAspirantsAsync(string monsterName);
    }
}
