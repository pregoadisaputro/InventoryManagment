using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Products.GetProducts;

public static class GetProductEndpoint
{
    public static void MapGetProducts(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/",
            async (InventoryDbContext dbContext, [AsParameters] GetProductsDto request) =>
            {
                var skipCount = (request.PageNumber - 1) * request.PageSize;

                var filteredProducts = dbContext.Products.Where(product =>
                    string.IsNullOrWhiteSpace(request.Name)
                    || EF.Functions.Like(product.Name, $"%{request.Name}%")
                );

                var productsOnPage = await filteredProducts
                    .OrderBy(product => product.Name)
                    .Skip(skipCount)
                    .Take(request.PageSize)
                    .Include(product => product.Category)
                    .Select(product => new ProductSummaryDto(
                        product.Id,
                        product.Name,
                        product.Sku,
                        product.Category!.Name,
                        product.Quantity,
                        product.StockThreshold,
                        product.Price,
                        product.CreatedAt,
                        product.LastUpdatedBy
                    ))
                    .AsNoTracking()
                    .ToListAsync();
            }
        );
    }
}
