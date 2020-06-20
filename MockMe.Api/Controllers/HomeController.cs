using Microsoft.AspNetCore.Mvc;

namespace MockMe.Api.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectPermanent("/swagger/index.html");
        }
    }
}
