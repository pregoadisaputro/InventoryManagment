namespace Backend.Features.Products.GetProduct;

public record ProductDetailsDto(
    int Id,
    string Name,
    string Sku,
    int CategoryId,
    int Quantity,
    int StockThreshold,
    decimal Price,
    DateTime CreatedAt,
    string LastUpdatedBy
);
