using Productos.Domain.Entities;

namespace Productos.Domain.Dtos;

public class ProductViewModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
}