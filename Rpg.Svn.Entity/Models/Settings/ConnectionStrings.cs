using Newtonsoft.Json;

namespace Rpg.Svn.Entity.Models.Settings
{
    public class ConnectionStrings
    {
        [JsonProperty("SvnContext")]
        public string SvnContext { get; set; }
    }
}
