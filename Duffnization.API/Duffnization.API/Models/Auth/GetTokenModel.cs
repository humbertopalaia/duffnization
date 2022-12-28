namespace Duffnization.API.Models.Auth
{
    public class GetTokenModel
    {
        public int SystemClientId { get; set; }
        public string Password { get; set; }
    }
}
