using Backend.Data;
using Backend.Features.Products.Constants;

namespace Backend.Features.Products.GetProduct;

public static class GetProductEndpoint
{
    public static void MapGetProduct(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/{id:int}",
                async (int id, InventoryDbContext dbContext) =>
                {
                    var existingItems = await dbContext.Products.FindAsync(id);

                    if (existingItems is null)
                    {
                        return Results.NotFound(
                            new
                            {
                                Title = "Not Found",
                                Detail = $"Product with ID {id} is not exist in inventory.",
                            }
                        );
                    }

                    var response = new ProductDetailsDto(
                        existingItems.Id,
                        existingItems.Name,
                        existingItems.Sku,
                        existingItems.CategoryId,
                        existingItems.Quantity,
                        existingItems.StockThreshold,
                        existingItems.Price,
                        existingItems.CreatedAt,
                        existingItems.LastUpdatedBy
                    );

                    return Results.Ok(response);
                }
            )
            .WithName(EndpointNames.GetProduct);
    }
}
