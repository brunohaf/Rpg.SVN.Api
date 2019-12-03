using System.ComponentModel.DataAnnotations;

namespace Rpg.Svn.Entity.Models
{
    public class DbSpell
    {
        [Key]
        public int SpellId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string HigherLevelDescription { get; set; }

        public string BookAndPage { get; set; }

        public string Range { get; set; }

        public string Components { get; set; }

        public string Material { get; set; }

        public string Ritual { get; set; }

        public string Duration { get; set; }

        public string Concentration { get; set; }

        public string Casting_time { get; set; }

        public string Level { get; set; }

        public int LevelInt { get; set; }

        public string MagicSchool { get; set; }

        public string BelongingClass { get; set; }

        public string BelongingArchetype { get; set; }

        public string BelongingCircles { get; set; }

    }
}
