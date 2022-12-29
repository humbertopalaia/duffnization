using AutoMapper;
using Duffnization.CRUD;
using Duffnization.CRUD.Domains.Search;
using Duffnization.Domain;
using Duffnization.Spotify;
using Duffnization.Spotify.Domains.Search;
using System.Collections.Generic;

namespace Duffnization.Business
{
    public class BearStyleBusiness : IBearStyleBusiness
    {
        private readonly IDuffnizationCRUDService _duffnizationCRUDService;
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;
        public BearStyleBusiness(IDuffnizationCRUDService duffnizationCRUDService, ISpotifyService spotifyService, IMapper mapper)
        {
            _duffnizationCRUDService = duffnizationCRUDService;
            _spotifyService = spotifyService;
            _mapper = mapper;
        }

        public async Task<Domain.BeerStyle> GetPlaylistSugestionByBeerStyle(string beerStyleName)
        {
            var beerStyleFromCRUD = await GetBeerStyleFromCRUD(null, beerStyleName);

            var beerStyle = await GenerateBeerStyle(beerStyleFromCRUD);

            return beerStyle;
        }

        public async Task<Domain.BeerStyle> GetPlaylistSugestionByTemperature(int temperature)
        {
            var beerStyleFromCRUD = await GetBeerStyleFromCRUD(temperature, null);

            var beerStyle = await GenerateBeerStyle(beerStyleFromCRUD);
            
            return beerStyle;
        }

        private async Task<CRUD.Domains.Search.BeerStyle> GetBeerStyleFromCRUD(int? temperature, string beerStyle)
        {
            CRUD.Domains.Search.BeerStyle beerStyleToReturn = new CRUD.Domains.Search.BeerStyle();

            var allBeers = await _duffnizationCRUDService.ListAll();

            if (!string.IsNullOrEmpty(beerStyle))
                allBeers = allBeers.Where(x => x.Name.Contains(beerStyle)).ToList();

            if (temperature.HasValue)
                beerStyleToReturn = allBeers.OrderByDescending(x => x.Name)
                                    .Aggregate((x, y) => Math.Abs(x.AverageTemperature - temperature.Value) < Math.Abs(y.AverageTemperature - temperature.Value) ? x : y);

            return beerStyleToReturn;
        }

        private async Task<Domain.BeerStyle> GenerateBeerStyle(CRUD.Domains.Search.BeerStyle beerStyleFromCrud)
        {
            var beerStyle = _mapper.Map<Domain.BeerStyle>(beerStyleFromCrud);
            var spotifySearch = await _spotifyService.SearchPlaylist(beerStyleFromCrud.Name);

            if (spotifySearch.Playlists.Total > 0)
            {
                //Choose a random playlist, if exists one or more
                var randomIndexPlayList = new Random().Next(0, spotifySearch.Playlists.Items.Count);
                var chosenPlaylist = spotifySearch.Playlists.Items[randomIndexPlayList];
                //-------------------------------------------------

                beerStyle.Playlist = _mapper.Map<Domain.Playlist>(chosenPlaylist);

                var tracksPlaylist = await _spotifyService.GetTracksPlaylist(chosenPlaylist.Id);
                beerStyle.Playlist.Tracks = _mapper.Map<List<Duffnization.Domain.Track>>(tracksPlaylist.Items);
            }
            else
                beerStyle = null;
            

            return beerStyle;

        }
    }
}