using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Productos.Domain.Entities;

namespace Productos.Infrastructure.Data;

public class ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : IdentityDbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Category> Category { get; set; }
}