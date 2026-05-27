using System.ComponentModel.DataAnnotations;

namespace Backend.Features.Products.CreateProduct;

public record CreateProductDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(10)] string Sku,
    [Required] int CategoryId,
    [Required] int Quantity,
    [Required] int StockThreshold,
    [Required] [Range(0.01, 100000.00)] decimal Price
);
