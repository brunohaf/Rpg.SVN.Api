using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rpg.Svn.Thirdparty.Facades
{
    public class Speed
    {
        [JsonProperty("walk")]
        public int Walk { get; set; }

        [JsonProperty("swim")]
        public int Swim { get; set; }

        [JsonProperty("hover")]
        public bool? Hover { get; set; }

        [JsonProperty("fly")]
        public int? Fly { get; set; }

        [JsonProperty("burrow")]
        public int? Burrow { get; set; }

        [JsonProperty("climb")]
        public int? Climb { get; set; }
    }

    public class Skills
    {
        [JsonProperty("history")]
        public int History { get; set; }

        [JsonProperty("perception")]
        public int Perception { get; set; }

        [JsonProperty("deception")]
        public int? Deception { get; set; }

        [JsonProperty("performance")]
        public int? Performance { get; set; }

        [JsonProperty("persuasion")]
        public int? Persuasion { get; set; }

        [JsonProperty("stealth")]
        public int? Stealth { get; set; }

        [JsonProperty("medicine")]
        public int? Medicine { get; set; }

        [JsonProperty("religion")]
        public int? Religion { get; set; }

        [JsonProperty("insight")]
        public int? Insight { get; set; }

        [JsonProperty("athletics")]
        public int? Athletics { get; set; }

        [JsonProperty("arcana")]
        public int? Arcana { get; set; }

        [JsonProperty("acrobatics")]
        public int? Acrobatics { get; set; }

        [JsonProperty("intimidation")]
        public int? Intimidation { get; set; }

        [JsonProperty("investigation")]
        public int? Investigation { get; set; }

        [JsonProperty("nature")]
        public int? Nature { get; set; }

        [JsonProperty("survival")]
        public int? Survival { get; set; }
    }

    public class Action
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("attack_bonus")]
        public int? Attack_bonus { get; set; }

        [JsonProperty("damage_dice")]
        public string Damage_dice { get; set; }

        [JsonProperty("damage_bonus")]
        public int? Damage_bonus { get; set; }
    }

    public class SpecialAbility
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }
    }

    public class Monster
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("armor_class")]
        public int Armor_class { get; set; }

        [JsonProperty("armor_desc")]
        public string Armor_desc { get; set; }

        [JsonProperty("hit_points")]
        public int Hit_points { get; set; }

        [JsonProperty("hit_dice")]
        public string Hit_dice { get; set; }

        [JsonProperty("speed")]
        public Speed Speed { get; set; }

        [JsonProperty("strenght")]
        public int Strength { get; set; }

        [JsonProperty("dexterity")]
        public int Dexterity { get; set; }

        [JsonProperty("constitution")]
        public int Constitution { get; set; }

        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty("wisdom")]
        public int Wisdom { get; set; }

        [JsonProperty("charisma")]
        public int Charisma { get; set; }

        [JsonProperty("strength_save")]
        public int? Strength_save { get; set; }

        [JsonProperty("dexterity_save")]
        public int? Dexterity_save { get; set; }

        [JsonProperty("constitution_save")]
        public int? Constitution_save { get; set; }

        [JsonProperty("intelligence_save")]
        public int? Intelligence_save { get; set; }

        [JsonProperty("wisdom_save")]
        public int? Wisdom_save { get; set; }

        [JsonProperty("charisma_save")]
        public int? Charisma_save { get; set; }

        [JsonProperty("perception")]
        public int? Perception { get; set; }

        [JsonProperty("skills")]
        public Skills Skills { get; set; }

        [JsonProperty("damage_vulnerabilities")]
        public string Damage_vulnerabilities { get; set; }

        [JsonProperty("damage_resistances")]
        public string Damage_resistances { get; set; }

        [JsonProperty("damage_immunities")]
        public string Damage_immunities { get; set; }

        [JsonProperty("condition_immunities")]
        public string Condition_immunities { get; set; }

        [JsonProperty("senses")]
        public string Senses { get; set; }

        [JsonProperty("languages")]
        public string Languages { get; set; }

        [JsonProperty("challenge_rating")]
        public string Challenge_rating { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }

        [JsonProperty("reactions")]
        public object Reactions { get; set; }

        [JsonProperty("legendary_desc")]
        public string Legendary_desc { get; set; }

        [JsonProperty("legendary_actions")]
        public object Legendary_actions { get; set; }

        [JsonProperty("special_abilities")]
        public List<SpecialAbility> Special_abilities { get; set; }

        [JsonProperty("img_main")]
        public string ImgUrl { get; set; }

        public bool NameIsMatch(string monsterName)
        {
            return Name.Equals(monsterName);
        }
    }

    public class MonsterResponse
    {
        [JsonProperty("results")]
        public List<Monster> MonsterList { get; set; }
    }
}
