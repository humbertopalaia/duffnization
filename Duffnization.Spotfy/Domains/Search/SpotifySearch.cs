using System.Text.Json.Serialization; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class SpotifySearch
    {
        [JsonPropertyName("playlists")]
        public Playlists Playlists { get; set; }
    }

}