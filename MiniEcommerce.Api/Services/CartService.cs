using Microsoft.Extensions.Caching.Distributed;
using MiniEcommerce.Api.Models;
using System.Text.Json;

namespace MiniEcommerce.Api.Services
{
    public interface ICartService
    {
        Task<ShoppingCart?> GetCartAsync(string cartId);
        Task<ShoppingCart> UpdateCartAsync(ShoppingCart cart);
        Task DeleteCartAsync(string cartId);
    }

    public class CartService : ICartService
    {
        //per il momento utilizzo la ram
        private readonly IDistributedCache _cache;

        public CartService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<ShoppingCart?> GetCartAsync(string cartId)
        {
            var data = await _cache.GetStringAsync(cartId);

            if (string.IsNullOrEmpty(data))
                return null;

            return JsonSerializer.Deserialize<ShoppingCart>(data);
        }

        public async Task<ShoppingCart> UpdateCartAsync(ShoppingCart cart)
        {
            var options = new DistributedCacheEntryOptions
            {
                //imposto la scadenza del carrello (ovvero la data dopo la quale viene pulito) a 30 giorni
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            };

            var data = JsonSerializer.Serialize(cart);
            await _cache.SetStringAsync(cart.CartId, data, options);

            return await GetCartAsync(cart.CartId) ?? cart;
        }

        public async Task DeleteCartAsync(string cartId)
        {
            await _cache.RemoveAsync(cartId);
        }
    }
}
