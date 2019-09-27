﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Svn.Api.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public string ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDies { get; set; }
        public Dictionary<string, string> Abilities { get; set; }
        public Dictionary<string, string> SavingThrows { get; set; }
        public Dictionary<string, string> Skills { get; set; }
        public IEnumerable<string> DamageImunities { get; set; }
    }
}
