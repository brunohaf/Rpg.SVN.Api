using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Svn.Api.Models
{
    public class MonsterResponse
    {
        public int Page { get; set; }
        public Dictionary<int, string> Values { get; set; }
    }
}
