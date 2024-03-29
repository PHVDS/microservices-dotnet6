using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindById(string id) 
        {
            var cart = await _repository.FindCartByUserId(id);
            if(cart == null) return NotFound(); 
                return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vO) 
        {
            var cart = await _repository.SaveOrUpdateCart(vO);
            if(cart == null) return NotFound(); 
                return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vO) 
        {
            var cart = await _repository.SaveOrUpdateCart(vO);
            if(cart == null) return NotFound(); 
                return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartVO>> RemoveCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(CartVO vO)
        {
            var status = await _repository.ApplyCoupon(vO.CartHeader.UserId, vO.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vO)
        {
            if(vO?.UserId == null) return BadRequest();
            var cart = await _repository.FindCartByUserId(vO.UserId);
            if (cart == null) return NotFound();
            vO.CartDetails = cart.CartDetails;
            vO.DateTime = DateTime.Now;
            //TASK RabbitMQ

            return Ok(vO);
        }

    }
}