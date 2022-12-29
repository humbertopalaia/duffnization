using Duffnization.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duffnization.Business
{
    public interface IBearStyleBusiness
    {
        Task<BeerStyle> GetPlaylistSugestionByTemperature(int temperature);
        Task<BeerStyle> GetPlaylistSugestionByBeerStyle(string beerStyle);
    }
}
