using System.Text.Json.Serialization; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; set; }
    }

}