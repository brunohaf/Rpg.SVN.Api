using System.Collections.Generic;

namespace Rpg.Svn.Thirdparty.Facades
{
    public class Monster
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public string ArmorClass { get; set; }
        public string HitPoints { get; set; }
        public string HitDies { get; set; }
        public Dictionary<string, string> Abilities { get; set; }
        public Dictionary<string, string> SavingThrows { get; set; }
        public Dictionary<string, string> Skills { get; set; }
        public IEnumerable<string> DamageImunities { get; set; }
        public IEnumerable<string> ConditionImunities { get; set; }
        public IEnumerable<string> Senses { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public string ImgUrl { get; set; }
        public string Challenge { get; set; }
        public string Description { get; set; }
    }
}
