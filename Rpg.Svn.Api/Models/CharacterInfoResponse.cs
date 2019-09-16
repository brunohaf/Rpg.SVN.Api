using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Svn.Api.Models
{
    public class CharacterInfoResponse
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Class { get; set; }
        public string Archetype { get; set; }
        public string ImgUrl { get; set; }
        public string Gender { get; set; }
        public string Level { get; set; }
        public string Fame { get; set; }
        public string Bio { get; set; }
        public string UthalCatchPhrase { get; set; }

    }
}
