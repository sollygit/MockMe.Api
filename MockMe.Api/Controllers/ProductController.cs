using Microsoft.AspNetCore.Mvc;
using MockMe.Api.Services;
using System.Threading.Tasks;

namespace MockMe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _productService.GetAll();
            return new OkObjectResult(items);
        }
    }
}
