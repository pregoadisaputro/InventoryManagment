using Backend.Data;
using Backend.Data.Models;
using Backend.Features.Products.Constants;
using Backend.Features.Products.GetProducts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Products.CreateProduct;

public static class CreateProductEndpoint
{
    public static void MapCreateProduct(this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/",
            async (CreateProductDto productDto, InventoryDbContext dbContext) =>
            {
                var skuExist = await dbContext.Products.AnyAsync(p => p.Sku == productDto.Sku);

                if (skuExist)
                {
                    return Results.BadRequest(
                        new
                        {
                            Title = "Bad Request",
                            Detail = $"SKU '{productDto.Sku}' already exist in inventory.",
                        }
                    );
                }

                var newProduct = new Product
                {
                    Name = productDto.Name,
                    Sku = productDto.Sku,
                    CategoryId = productDto.CategoryId,
                    Quantity = productDto.Quantity,
                    StockThreshold = productDto.StockThreshold,
                    Price = productDto.Price,
                };

                dbContext.Add(newProduct);
                await dbContext.SaveChangesAsync();

                var response = new ProductDetailsDto(
                    newProduct.Id,
                    newProduct.Name,
                    newProduct.Sku,
                    newProduct.CategoryId,
                    newProduct.Quantity,
                    newProduct.StockThreshold,
                    newProduct.Price,
                    newProduct.LastUpdatedBy
                );

                return Results.CreatedAtRoute(
                    EndpointNames.GetProduct,
                    new { id = newProduct.Id },
                    response
                );
            }
        );
    }
}
