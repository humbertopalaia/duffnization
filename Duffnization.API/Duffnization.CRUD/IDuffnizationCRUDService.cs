using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duffnization.CRUD.Domains;
using Duffnization.CRUD.Domains.Search;

namespace Duffnization.Spotify
{
    public interface IDuffnizationCRUDService
    {
        Task<DuffnizationCRUDToken> GetTokenAsync();
        Task<List<BeetStyle>> GetByTemperature(int temperature);
    }
}
