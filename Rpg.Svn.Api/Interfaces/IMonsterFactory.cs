using Rpg.Svn.Thirdparty.Models;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IMonsterFactory
    {
        Monster GenerateMonster(string monsterName);
    }
}
