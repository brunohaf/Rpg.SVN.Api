using Rpg.Svn.Core.Models;
using Rpg.Svn.Entity.Models;

namespace Rpg.Svn.Core.Contracts
{
    public interface IDbSpellService
    {
        BaseResponse<DbSpell>.Collection ListAll();
        BaseResponse<DbSpell> Save(DbSpell data);
        BaseResponse<DbSpell> GetById(int id);
    }
}
