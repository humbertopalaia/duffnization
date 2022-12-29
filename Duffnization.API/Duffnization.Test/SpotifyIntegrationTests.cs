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

        [TestCase("Simpson")]
        public async Task SearchPlaylist(string playlistName)
        {
            var response = await _spotifyService.SearchPlaylist(playlistName);

            Assert.IsNotNull(response);
        }

        [TestCase("djkfior4ejofsdnmdsamklewqo")]
        public async Task SearchPlaylistNotFound(string playlistName)
        {
            var response = await _spotifyService.SearchPlaylist(playlistName);

            Assert.IsTrue(response.Playlists.Items.Count == 0);
        }

        [TestCase("idinvalido")]
        public async Task TestInvalidGetTracksPlaylist(string playlistId)
        {
            var response = await _spotifyService.GetTracksPlaylist(playlistId);

            Assert.IsTrue(string.IsNullOrEmpty(response.Href));
        }



        [TestCase("1Ombu7CWZoaQEILrWIiZI0")]
        public async Task TestValidGetTracksPlaylist(string playlistId)
        {
            var response = await _spotifyService.GetTracksPlaylist(playlistId);

            Assert.IsTrue(response.Href == "https://api.spotify.com/v1/playlists/1Ombu7CWZoaQEILrWIiZI0/tracks?offset=0&limit=100");
        }
    }
}