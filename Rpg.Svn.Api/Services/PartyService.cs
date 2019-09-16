using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Rpg.Svn.Api.Exceptions;
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

        public CharacterInfoResponse GetCharacterInfo(string character)
        {
            try
            {
                if (CharacterEnumerations.Contains(character))
                {
                    return _partyInfo.GetCharacterInfoById(CharacterEnumerations.GetIdByName(character));
                }
            }
            catch (NotAMainCharException e)
            {
                
            }
            return null;
        }

        public Uri UriTest(Uri url)
        {
            var inteiro = 1;
            var teste = "%Teste";
            var rawQuery = HttpUtility.ParseQueryString(url.Query);
            rawQuery["origem"] = teste;
            rawQuery["dafuq"] = $"{inteiro}";
            var uriBuilder = new UriBuilder(url);
            uriBuilder.Query = rawQuery.ToString();
            
            var resultUrl = uriBuilder.Uri;
            return resultUrl;
        }
    }
}
