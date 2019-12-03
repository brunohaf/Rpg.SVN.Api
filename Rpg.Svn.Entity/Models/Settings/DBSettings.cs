using Newtonsoft.Json;

namespace Rpg.Svn.Entity.Models.Settings
{
    public class DBSettings
    {
        [JsonProperty("ConnectionStrings")]
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
