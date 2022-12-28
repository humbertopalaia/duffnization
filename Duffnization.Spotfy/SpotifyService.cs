using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Duffnization.Spotify.Domains;
using Duffnization.Spotify.Domains.Search;

namespace Duffnization.Spotify
{
    public class SpotifyService : ISpotifyService
    {
        private readonly SpotifyConfig _config;
        
        public SpotifyService(SpotifyConfig config)
        {
            _config = config;
        }

        public async Task<SpotifyToken> GetTokenAsync()
        {
            SpotifyToken spotifyToken = null;

            try
            {
                string clientId = _config.ClientId;
                string clientSecret = _config.ClientSecret;
                string credentials = String.Format("{0}:{1}", clientId, clientSecret);

                using (var client = new HttpClient())
                {
                    //Define Headers
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                    //Prepare Request Body
                    List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                    requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                    FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                    //Request Token
                    var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
                    var response = await request.Content.ReadAsStringAsync();
                    spotifyToken = System.Text.Json.JsonSerializer.Deserialize<SpotifyToken>(response);
                }
            }
            catch (Exception)
            {
                spotifyToken = null;
            }


            return spotifyToken;
        }

        public async Task<SpotifySearch> SearchPlaylist(string playlist)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (string.IsNullOrEmpty(playlist))
                        return null;

                    var url = _config.BaseApiUrl + $"/v1/search?q={playlist}&type=playlist";
                    var spotifyToken = await GetTokenAsync();

                    if (spotifyToken != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spotifyToken.AccessToken);

                        //Prepare Request Body
                        //Request Token
                        var request = await client.GetAsync(url);
                        var response = await request.Content.ReadAsStringAsync();
                        return System.Text.Json.JsonSerializer.Deserialize<SpotifySearch>(response);
                    }
                    else
                        return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public string SearchPlaylist(string playlistName)
        //{
        //    Ht
        //}
    }
}
