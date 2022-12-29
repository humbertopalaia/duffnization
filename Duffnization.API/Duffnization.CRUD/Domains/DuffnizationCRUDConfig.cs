using System.Text.Json.Serialization;

namespace Duffnization.CRUD.Domains
{
    public class DuffnizationCRUDConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseApiUrl { get; set; }
    }
}