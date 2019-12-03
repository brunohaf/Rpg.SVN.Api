using System.Linq;
using Rpg.Svn.Core.Contracts;
using Rpg.Svn.Core.Models;
using Rpg.Svn.Entity.Models;
using Rpg.Svn.Repository;

namespace Rpg.Svn.Bll
{
    public class DbSpellService : IDbSpellService
    {
        public BaseResponse<DbSpell> GetById(int id)
        {
            var response = new BaseResponse<DbSpell>();
            using (var _tbActivityRepository = new DbSpellRepository())
            {
                response.Content = _tbActivityRepository.Filter(p => p.SpellId == id).List.FirstOrDefault();
            }
            return response;
        }

        public BaseResponse<DbSpell>.Collection ListAll()
        {
            var response = new BaseResponse<DbSpell>.Collection();
            using (var _tbActivityRepository = new DbSpellRepository())
            {
                response = _tbActivityRepository.Filter();
            }
            return response;
        }

        public BaseResponse<DbSpell> Save(DbSpell data)
        {
            var response = new BaseResponse<DbSpell>();
            using (var _tbActivityRepository = new DbSpellRepository())
            {
                response = _tbActivityRepository.Save(data);
            }
            return response;
        }
    }
}

