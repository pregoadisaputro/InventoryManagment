namespace Backend.Features.Products.GetProducts;

public record GetProductsDto(int PageNumber = 1, int PageSize = 5, string? Name = null);

public record ProductPageDto(int TotalPages, IEnumerable<ProductDetailsDto> Data);
