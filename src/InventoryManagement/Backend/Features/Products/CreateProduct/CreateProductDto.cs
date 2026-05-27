using System.ComponentModel.DataAnnotations;

namespace Backend.Features.Products.CreateProduct;

public record CreateProductDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(50)] string Sku,
    [Required] int CategoryId,
    [Required] int Quantity,
    [Required] int StockThreshold,
    [Required] [Range(0.01, 100000.00)] decimal Price
);

public record ProductDetailsDto(
    int Id,
    string Name,
    string Sku,
    int CategoryId,
    int Quantity,
    int StockThreshold,
    decimal Price,
    string LastUpdatedBy
);
