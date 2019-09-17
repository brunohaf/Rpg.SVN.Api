using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rpg.Svn.Api.Models
{
    public class PartyInfo
    {
        /// <summary>
        /// Noon's info
        /// </summary>
        [JsonProperty("Noon")]
        public CharacterInfoResponse Noon { get; set; }

        /// <summary>
        /// Maegor's info
        /// </summary>
        [JsonProperty("Maegor")]
        public CharacterInfoResponse Maegor { get; set; }

        public IEnumerable<CharacterInfoResponse> ToList()
        {
            var charList = new List<CharacterInfoResponse>();
            charList.Add(Maegor);
            charList.Add(Noon);

            return charList;
        }
        public CharacterInfoResponse GetCharacterInfoById(int id) 
        {
            var charList = ToList();
            foreach(var character in charList)
            {
                if (character.Id.Equals(id))
                {
                    return character;
                }
            }
            return null;
        }
    }

}
