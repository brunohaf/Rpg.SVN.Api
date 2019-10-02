using System.Collections.Generic;
using System.Threading.Tasks;
using Rpg.Svn.Thirdparty.Models;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IMonsterService
    {
        Monster GetMonsterbyName(string monsterName);
        Task<Dictionary<int, string>> GetMonsterAspirantsAsync(string monsterName);
    }
}
