using System.ComponentModel.DataAnnotations;

namespace Backend.Features.Products.UpdateProduct;

public record UpdateProductDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(50)] string Sku,
    [Required] int CategoryId,
    [Required] int Quantity,
    [Required] int StockThreshold,
    [Required] [Range(0.01, 100000.00)] decimal Price
);
