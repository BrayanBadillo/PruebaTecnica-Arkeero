using System.ComponentModel.DataAnnotations;

namespace Productos.Models;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name Category Is Required!")]
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; }
}