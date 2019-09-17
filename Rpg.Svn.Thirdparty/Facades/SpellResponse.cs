using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rpg.Svn.Thirdparty.Facades
{
    public class Spell
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Desc { get; set; }
        [JsonProperty("higher_level")]
        public string HigherLevelDesc { get; set; }
        [JsonProperty("range")]
        public string Range { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("concentration")]
        public string Concentration { get; set; }
        [JsonProperty("ritual")]
        public string Ritual { get; set; }
        [JsonProperty("casting_time")]
        public string CastingTime { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("level_int")]
        public string IntLevel { get; set; }
        [JsonProperty("dnd_class")]
        public string BelongingClass { get; set; }
        [JsonProperty("school")]
        public string SpellSchool { get; set; }
        [JsonProperty("archetype")]
        public string BelongingArchetype { get; set; }
        [JsonProperty("circles")]
        public string BelongingCircle { get; set; }
    }

    public class SpellResponse
    {
        public List<Spell> SpellList { get; set; }
    }
}
