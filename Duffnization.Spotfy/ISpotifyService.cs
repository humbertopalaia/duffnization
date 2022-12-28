using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duffnization.Spotify.Domains;
using Duffnization.Spotify.Domains.Search;

namespace Duffnization.Spotify
{
    public interface ISpotifyService
    {
        Task<SpotifyToken> GetTokenAsync();
        Task<SpotifySearch> SearchPlaylist(string playlist);
    }
}
