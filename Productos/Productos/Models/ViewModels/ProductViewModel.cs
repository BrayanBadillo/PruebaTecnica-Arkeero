namespace Productos.Models.ViewModels;

public class ProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}
