using System;
using Rpg.Svn.Entity.Models;

namespace Rpg.Svn.Core.Contracts
{
    public interface IDbSpellRepository : IGenericEF<DbSpell>, IDisposable
    {
    }
}
