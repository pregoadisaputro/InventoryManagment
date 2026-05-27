using Backend.Data;

namespace Backend.Features.Products.DeleteProduct;

public static class DeleteProductEndpoint
{
    public static void MapDeleteProduct(this IEndpointRouteBuilder app)
    {
        app.MapDelete(
            "/{id:int}",
            async (int id, InventoryDbContext dbContext) =>
            {
                var existingProducts = await dbContext.Products.FindAsync(id);

                if (existingProducts is null)
                {
                    return Results.Problem(
                        detail: $"Product with ID '{id}' does not exist in the inventory.",
                        statusCode: StatusCodes.Status404NotFound,
                        title: "Product Not Found"
                    );
                }

                dbContext.Remove(existingProducts);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );
    }
}
