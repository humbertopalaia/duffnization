using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class Playlist
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

}