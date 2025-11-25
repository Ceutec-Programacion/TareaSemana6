using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly List<string> Customers = new()
        {
            "Customer 1: John Deere",
            "Customer 2: Axel Roses",
            "Customer 3 : Bob Marley",
            "Customer 4 : Michael Williams",
        };
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(Customers);
        }
    }
}
