namespace Backend.Features.Products.GetProducts;

public record GetProductsDto(int PageNumber = 1, int PageSize = 5, string? Name = null);

public record ProductPageDto(int TotalPages, IEnumerable<ProductSummaryDto> Data);

public record ProductSummaryDto(
    int Id,
    string Name,
    string Sku,
    string CategoryName,
    int Quantity,
    int StockThreshold,
    decimal Price,
    DateTime CreatedAt,
    string LastUpdatedBy
);
