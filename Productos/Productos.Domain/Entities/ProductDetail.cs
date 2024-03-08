namespace Productos.Domain.Entities;

public class ProductDetail
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Quantity { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; }
}