using System.Text.Json.Serialization; 
using System.Collections.Generic;
using Duffnization.Spotify.Domains.GetTracksPlayList;

namespace Duffnization.Spotify.Domains.GetTracksPlaylist{ 

    public class Track
    {

        [JsonPropertyName("artists")]
        public List<Artist> Artists { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }


        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }
    }

}