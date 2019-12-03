using System;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rpg.Svn.Entity.Models;
using Rpg.Svn.Entity.Models.Settings;

namespace Rpg.Svn.Entity
{
    public class SvnContext : DbContext
    {
        public DbSet<DbMonster> DbMonster { get; set; }

        public DbSet<DbSpell> DbSpell { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbSettings = string.Empty;
#if DEBUG
            dbSettings = $"{AppDomain.CurrentDomain.BaseDirectory}dbsettings.Development.json";
#else
            dbSettings = $"{AppDomain.CurrentDomain.BaseDirectory}dbsettings.json";
#endif
            var connectionString = JsonConvert.DeserializeObject<DBSettings>(File.ReadAllText(dbSettings, Encoding.UTF8)).ConnectionStrings;
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString.SvnContext);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
