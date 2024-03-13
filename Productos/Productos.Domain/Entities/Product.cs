using System.ComponentModel.DataAnnotations;

namespace Productos.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name Product is Required!")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "The Description is Required!")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "The Price is Required!")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price Must Be Greater Than Zero!")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Quantity is Required!")]
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}