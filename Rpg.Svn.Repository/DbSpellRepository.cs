using Rpg.Svn.Core.Contracts;
using Rpg.Svn.Entity;
using Rpg.Svn.Entity.Models;

namespace Rpg.Svn.Repository
{
    public class DbSpellRepository : GenericEF<DbSpell, SvnContext>, IDbSpellRepository
    {
        public void Dispose()
        {
        }
    }
}
