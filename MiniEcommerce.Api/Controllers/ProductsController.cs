using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Api.Data;
using MiniEcommerce.Api.Models;

namespace MiniEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context) { 
            _context = context;

            //Seed del db inmemory: se è vuoto vengono aggiunti due prodotti
            if (!_context.Products.Any()) 
            {
                _context.Products.Add(new Product { Name = "Laptop", Description = "PC ad alte prestazioni", Price = 1299.99m, Stock = 10});
                _context.Products.Add(new Product { Name = "Mouse Wireless", Description = "Mouse ergonomico", Price = 29.50m, Stock= 50});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); //Restituisce 404 se non trovato
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product) 
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id =  product.Id }, product);
        }
    }
}
