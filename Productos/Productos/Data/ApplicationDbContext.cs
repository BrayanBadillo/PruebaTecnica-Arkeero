using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Productos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
        }

        private DbSet<Product> Products { get; set; }
        private DbSet<ProductDetail> ProductDetails { get; set; }
        private DbSet<Category> Category { get; set; }
    }
}