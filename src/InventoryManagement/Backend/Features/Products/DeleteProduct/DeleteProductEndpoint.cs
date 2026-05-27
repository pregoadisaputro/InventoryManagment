using Backend.Data;

namespace Backend.Features.Products.DeleteProduct;

public static class DeleteProductEnpoint
{
    public static void MapDeleteProduct(IEndpointRouteBuilder app)
    {
        app.MapDelete(
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

                dbContext.Remove(existingItems);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );
    }
}
