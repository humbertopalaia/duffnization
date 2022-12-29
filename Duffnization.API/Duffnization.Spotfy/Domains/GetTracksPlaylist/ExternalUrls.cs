using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Duffnization.Spotify.Domains.GetTracksPlayList{ 

    public class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; set; }
    }

}