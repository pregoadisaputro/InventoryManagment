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

                var query = dbContext.Products.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    query = query.Where(product =>
                        EF.Functions.ILike(product.Name, $"%{request.Name}%")
                    );
                }

                var totalProducts = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalProducts / (double)request.PageSize);

                var productsOnPage = await query
                    .OrderBy(product => product.Name)
                    .Skip(skipCount)
                    .Take(request.PageSize)
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
                    .ToListAsync();

                return Results.Ok(new ProductPageDto(totalPages, productsOnPage));
            }
        );
    }
}
