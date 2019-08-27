using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Api.Models;

namespace Rpg.Svn.Api.Interfaces
{
    public interface IPartyService
    {
        CharacterInfoResponse GetCharacterInfo();
    }
}
