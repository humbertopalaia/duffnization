using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Duffnization.Spotify.Domains.Search{ 

    public class Item
    {
        [JsonPropertyName("collaborative")]
        public bool Collaborative { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("primary_color")]
        public object PrimaryColor { get; set; }

        [JsonPropertyName("public")]
        public object Public { get; set; }

        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; }

        [JsonPropertyName("tracks")]
        public Tracks Tracks { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

}