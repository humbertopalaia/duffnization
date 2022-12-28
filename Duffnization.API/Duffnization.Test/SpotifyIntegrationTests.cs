using Duffnization.Spotify;
using Duffnization.Spotify.Domains;

namespace Duffnization.Test
{
    public class SpotifyIntegrationTests
    {
        private ISpotifyService _spotifyService;

        [SetUp]
        public void Setup()
        {
            _spotifyService = new SpotifyService(new SpotifyConfig
            {
                ClientId = "34b45dce9d654dd4988b6181831e6106",
                ClientSecret = "2615bd6157054f0b85a4a15d94abc424",
                AuthUrl = "https://accounts.spotify.com/api/token",
                BaseApiUrl = "https://api.spotify.com"
            });
        }

        [Test]
        public async Task GetTokenAsync()
        {
            var spotifyToken = await _spotifyService.GetTokenAsync();

            Assert.IsNotNull(spotifyToken);
        }

        [Test]
        public async Task SearchPlaylist()
        {
            var response = await _spotifyService.SearchPlaylist("Simpson");

            Assert.IsNotNull(response);
        }
    }
}