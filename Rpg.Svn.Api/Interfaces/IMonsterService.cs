using System.Collections.Generic;
using System.Threading.Tasks;
using Rpg.Svn.Api.Models;
using Rpg.Svn.Thirdparty.Models;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IMonsterService
    {
        Monster GetMonsterbyName(string monsterName);
        Task<IEnumerable<MonsterResponse>> GetMonsterAspirantsAsync(string monsterName);
    }
}
