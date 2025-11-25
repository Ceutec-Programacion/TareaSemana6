using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly List<string> Customers = new()
        {
            "Customer 1: John Doe",
            "Customer 2: Jane Smith",
            "Customer 3 : Bob Johnson",
            "Customer 4 : Alice Williams",
        };
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(Customers);
        }
    }
}
