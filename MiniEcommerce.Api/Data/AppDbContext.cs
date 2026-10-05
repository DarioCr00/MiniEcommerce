using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Api.Models;

namespace MiniEcommerce.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Rappresenta la tabella prodotti
        public DbSet<Product> Products { get; set; }
    }
}
