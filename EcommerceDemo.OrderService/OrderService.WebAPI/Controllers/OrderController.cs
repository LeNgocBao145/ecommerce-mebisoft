using Microsoft.AspNetCore.Mvc;

namespace OrderService.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCart(Guid userId)
        {
            // Logic to retrieve the cart
            return Ok();
        }
        //[HttpPost("add")]
        //public IActionResult CreateCart([FromBody] Cart cart)
        //{
        //    // Logic to create a new cart
        //    return Ok();
        //}
        //[HttpPut("items/{itemId}")]
        //public IActionResult UpdateCartItem(Guid itemId, [FromBody] CartItems cartItem)
        //{
        //    // Logic to update a cart item
        //    return Ok();
        //}
        [HttpDelete]
        public IActionResult DeleteCart(Guid cartId)
        {
            // Logic to delete a cart
            return Ok();
        }
    }
}
