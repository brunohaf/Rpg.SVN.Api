using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Api.Models;

namespace Rpg.Svn.Api.Services
{
    public class PartyService : IPartyService 
    {
        private readonly PartyInfo _partyInfo;
        public PartyService (PartyInfo partyInfo)
        {
            _partyInfo = partyInfo;
        }

        public CharacterInfoResponse GetCharacterInfo()
        {

            return _partyInfo.Maegor;
        }
    }
}
