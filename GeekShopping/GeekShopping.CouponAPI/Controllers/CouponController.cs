using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ILogger<CouponController> _logger;

        public CouponController(ILogger<CouponController> logger)
        {
            _logger = logger;
        }
    }
}