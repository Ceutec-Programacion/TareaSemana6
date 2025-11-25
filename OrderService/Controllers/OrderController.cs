using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly List<string> Orders = new()
        {
            "Order #1001: 2x Widget A, 1x Widget B",
            "Order #1002: 1x Widget C",
            "Order #1003: 5x Widget A, 3x Widget D",
            "Order #1004: 2x Widget B, 2x Widget C",
            "Order #1005: 1x Widget D, 4x Widget A"
        };
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(Orders);
        }
    }
}
