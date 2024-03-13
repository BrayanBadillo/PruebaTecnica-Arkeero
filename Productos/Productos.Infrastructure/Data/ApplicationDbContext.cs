using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Productos.Domain.Entities;

namespace Productos.Infrastructure.Data;

public class ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : IdentityDbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating( ModelBuilder builder )
    {
        builder.Entity<Category>()
            .HasMany(p => p.Products)
            .WithOne(c => c.Category)
            .HasForeignKey("CategoryId")
            .IsRequired();

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Herramientas Electricas" },
                 new Category { Id = 2, Name = "Herramientas Manuales" }
            );

        builder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Taladro 1/2 500W Beta", Description = "Taladro de 500W de 1/2\" con velocidad variable de 0 - 3000 RPM, incluye Mango, Guía y llave para sacar broca, Tutoriales sobre el buen uso de la herramienta. ", Price = 139500, Quantity = 10, CategoryId = 1, CreatedAt = DateTime.UtcNow },
            new Product { Id = 2, Name = "Taladro 1/4 420W Avinci", Description = "Taladro de 420W de 1/4\" con velocidad variable de 0 - 4200 RPM, incluye Catálogo, Llave para mandril. Tutoriales sobre el buen uso de la herramienta. ", Price = 122100, Quantity = 5, CategoryId = 1, CreatedAt = DateTime.UtcNow }
            );
        base.OnModelCreating(builder);
    }
}