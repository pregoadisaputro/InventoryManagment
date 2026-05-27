using Backend.Data;

namespace Backend.Features.Products.UpdateProduct;

public static class UpdateProductEndpoint
{
    public static void MapUpdateProduct(this IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/{id:int}",
            async (int id, UpdateProductDto productDto, InventoryDbContext dbContext) =>
            {
                var existingProduct = await dbContext.Products.FindAsync(id);

                if (existingProduct is null)
                {
                    return Results.NotFound(
                        new
                        {
                            Title = "Not Found",
                            Detail = $"Product with ID '{id}' not exist in inventory.",
                        }
                    );
                }

                existingProduct.Name = productDto.Name;
                existingProduct.Sku = productDto.Sku;
                existingProduct.CategoryId = productDto.CategoryId;
                existingProduct.Quantity = productDto.Quantity;
                existingProduct.StockThreshold = productDto.StockThreshold;
                existingProduct.Price = productDto.Price;

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );
    }
}
