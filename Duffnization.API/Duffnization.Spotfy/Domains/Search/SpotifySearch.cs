using System.Text.Json.Serialization; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class SpotifySearch
    {
        [JsonPropertyName("playlists")]
        public Playlist Playlists { get; set; }
    }

}