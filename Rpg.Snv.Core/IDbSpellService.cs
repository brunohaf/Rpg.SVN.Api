using Rpg.Svn.Entity.Models;
using Rpg.Svn.Repository.Responses;

namespace Rpg.Snv.Core
{
    public interface IDbSpellService
    {
            BaseResponse<DbSpell>.Collection ListAll();
            BaseResponse<DbSpell> Save(DbSpell data);
            BaseResponse<DbSpell> GetById(int id);
        
    }
}
