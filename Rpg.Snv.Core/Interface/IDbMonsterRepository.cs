using System;

using Rpg.Svn.Entity.Models;
using Rpg.Svn.Repository.Interfaces;

namespace Rpg.Snv.Core.Interface
{
    public interface IDbMonsterRepository : IGenericEF<DbMonster>, IDisposable
    {
    }
}
