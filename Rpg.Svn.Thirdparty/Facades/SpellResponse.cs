using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rpg.Svn.Thirdparty.Facades
{
    public class Spell
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("higher_level")]
        public string Higher_level { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

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
        public int Level_int { get; set; }

        [JsonProperty("school")]
        public string School { get; set; }

        [JsonProperty("dnd_class")]
        public string Dnd_class { get; set; }

        [JsonProperty("archetype")]
        public string Archetype { get; set; }

        [JsonProperty("circles")]
        public string Circles { get; set; }

        [JsonProperty("document__slug")]
        public string Document__slug { get; set; }

        [JsonProperty("document__title")]
        public string Document__title { get; set; }
    }

    public class SpellResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<Spell> SpellList { get; set; }
    }
}
