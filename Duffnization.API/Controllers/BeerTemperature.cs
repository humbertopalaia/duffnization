using Microsoft.AspNetCore.Mvc;

namespace Duffnization.API.Controllers
{

    [Route("api/[controller]")]
    //    [Authorize]
    public class BeerTemperature : Controller
    {
        [HttpGet("GetIdealBeer")]
        public IActionResult GetIdealBeer(int temperature)
        {
            return Json(new { temperature });
        }
    }
}
