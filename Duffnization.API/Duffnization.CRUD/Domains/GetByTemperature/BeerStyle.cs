using System.Text.Json.Serialization; 
namespace Duffnization.CRUD.Domains.Search{ 

    public class BeerStyle
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("minTemperature")]
        public int MinTemperature { get; set; }

        [JsonPropertyName("maxTemperature")]
        public int MaxTemperature { get; set; }

        [JsonPropertyName("averageTemperature")]
        public int AverageTemperature { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("updateDate")]
        public DateTime? UpdateDate { get; set; }
    }

}