using System.Text.Json.Serialization; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class Tracks
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

}