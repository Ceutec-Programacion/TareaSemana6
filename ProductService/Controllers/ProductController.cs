using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<string> Evaluations = new()
        {
            "Excellent product, highly recommend!",
            "Good value for the price.",
            "Average quality, could be better.",
            "Not satisfied with the performance.",
            "Exceeded my expectations!"
        };

        [HttpGet]
        public IActionResult getall()
        {
            return Ok(Evaluations);
        }
    }
}
