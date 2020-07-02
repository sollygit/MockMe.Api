using Microsoft.AspNetCore.Mvc;
using MockMe.Api.Services;
using System.Threading.Tasks;

namespace MockMe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _countryService.GetAll();
            return new OkObjectResult(items);
        }
    }
}
