using Duffnization.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Duffnization.API.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class BeerPlayListController : Controller
    {

        private readonly IBearStyleBusiness _bearStyleBusiness;

        public BeerPlayListController(IBearStyleBusiness bearStyleBusiness)
        {
            _bearStyleBusiness = bearStyleBusiness;
        }

        [HttpGet("GetPlaylistSugestionByTemperature")]
        public async Task<IActionResult> GetPlaylistSugestionByTemperature(int temperature)
        {
            try
            {
                var bearStyle = await _bearStyleBusiness.GetPlaylistSugestionByTemperature(temperature);

                if (bearStyle?.Playlist == null)
                    return NotFound("No playlists found");
                else
                    return Json(bearStyle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem("Error getting data, try again later");
            }
            
        }


        [HttpGet("GetPlayListSugestionByBeerStyle")]
        public async Task<IActionResult> GetPlayListSugestionByBeerStyle(string beerStyle)
        {
            try
            {
                var bearStyle = await _bearStyleBusiness.GetPlaylistSugestionByBeerStyle(beerStyle);

                if (bearStyle.Playlist == null)
                    return NotFound("No playlists found");
                else
                    return Json(bearStyle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem("Error getting data, try again later");
            }

        }
    }
}
