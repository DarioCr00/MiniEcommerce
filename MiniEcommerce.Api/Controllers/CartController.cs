using Microsoft.AspNetCore.Mvc;
using MiniEcommerce.Api.Models;
using MiniEcommerce.Api.Services;

namespace MiniEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) 
        { 
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetCart(string id)
        {
            var cart = await _cartService.GetCartAsync(id);

            //invece di restituire errore, facciamo in modo che restituisca un carrello vuoto
            return Ok(cart ?? new ShoppingCart { CartId = id });
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart) 
        {
            var updatedCart = await _cartService.UpdateCartAsync(cart);
            return Ok(updatedCart);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart (string id) 
        {
            await _cartService.DeleteCartAsync(id);
            return NoContent();
        }
        
    }
}
