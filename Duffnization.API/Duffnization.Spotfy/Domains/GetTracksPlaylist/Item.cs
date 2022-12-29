using System.Text.Json.Serialization; 
using System.Collections.Generic; 
using System; 
namespace Duffnization.Spotify.Domains.GetTracksPlaylist{ 

    public class Item
    {
        [JsonPropertyName("track")]
        public Track Track { get; set; }
    }

}