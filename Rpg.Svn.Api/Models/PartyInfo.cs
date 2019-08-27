using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    }

}
