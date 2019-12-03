using Rpg.Svn.Core.Contracts;
using Rpg.Svn.Entity;
using Rpg.Svn.Entity.Models;

namespace Rpg.Svn.Repository
{
    public class DbMonsterRepository : GenericEF<DbMonster, SvnContext>, IDbMonsterRepository
    {
        public void Dispose()
        {
        }
    }
}
