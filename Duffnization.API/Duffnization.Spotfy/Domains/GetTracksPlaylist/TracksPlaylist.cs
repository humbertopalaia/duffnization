using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Duffnization.Spotify.Domains.GetTracksPlaylist{ 

    public class TracksPlaylist
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }

    }

}