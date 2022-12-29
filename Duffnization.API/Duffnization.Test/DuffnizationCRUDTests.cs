using Duffnization.CRUD.Domains;
using Duffnization.Spotify;
using Duffnization.Spotify.Domains;

namespace Duffnization.Test
{
    public class DuffnizationCRUDTests
    {
        private IDuffnizationCRUDService _duffnizationCRUDService;

        [SetUp]
        public void Setup()
        {
            _duffnizationCRUDService = new DuffnizationCRUDService(new DuffnizationCRUDConfig
            {
                Username = "admin",
                Password = "admin",
                BaseApiUrl = "http://localhost:8000"
            });
        }

        [Test]
        public async Task GetTokenAsync()
        {
            var token = await _duffnizationCRUDService.GetTokenAsync();

            Assert.IsNotNull(token);
        }

        [Test]
        public async Task GetByTemperature()
        {
            var response = await _duffnizationCRUDService.GetByTemperature(-2);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0);
        }
    }
}