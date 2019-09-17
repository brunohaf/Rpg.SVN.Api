using Newtonsoft.Json;

namespace Rpg.Svn.Api
{
    /// <summary>
    /// Class to use data from appsettings.json "Settings" field
    /// </summary>
    public class MySettings
    {
        /// <summary>
        /// BLiP's bot identifier and access key
        /// </summary>
        [JsonProperty("BlipBotSettings")]
        public BlipBotSettings BlipBotSettings { get; set; }
        [JsonProperty("ThirdPartySettings")]
        public ThirdPartySettings ThirdPartySettings { get; set; }
    }

    public class BlipBotSettings
    {
        /// <summary>
        /// BLiP's bot identifier
        /// </summary>
        [JsonProperty("Identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// BLiP's bot access key
        /// </summary>
        [JsonProperty("AccessKey")]
        public string AccessKey { get; set; }

        /// <summary>
        /// BLiP's bot Authorization Key
        /// </summary>
        [JsonProperty("Authorization")]
        public string Authorization { get; set; }
    }
    public class ThirdPartySettings
    {
        [JsonProperty("open5eBaseUrl")]
        public string Open5eBaseUrl { get; set; }
    }
}
