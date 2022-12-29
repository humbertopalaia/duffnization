using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Duffnization.Spotify.Domains.GetTracksPlaylist{ 

    public class Artist
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

}