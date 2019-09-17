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
        public string Description { get; set; }

        [JsonProperty("higher_level")]
        public string HigherLevelDescription { get; set; }

        [JsonProperty("page")]
        public string BookAndPage { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("components")]
        public string Components { get; set; }

        [JsonProperty("material")]
        public string Material { get; set; }

        [JsonProperty("ritual")]
        public string Ritual { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("concentration")]
        public string Concentration { get; set; }

        [JsonProperty("casting_time")]
        public string Casting_time { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("level_int")]
        public int LevelInt { get; set; }

        [JsonProperty("school")]
        public string MagicSchool { get; set; }

        [JsonProperty("dnd_class")]
        public string BelongingClass { get; set; }

        [JsonProperty("archetype")]
        public string BelongingArchetype { get; set; }

        [JsonProperty("circles")]
        public string BelongingCircles { get; set; }

        public bool NameIsMatch(string spellName)
        {
            return Name.Equals(spellName);
        }
    }

    public class SpellResponse
    {
        [JsonProperty("results")]
        public List<Spell> SpellList { get; set; }
    }
}
