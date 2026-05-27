using Backend.Features.Products.CreateProduct;

namespace Backend.Features.Products;

public static class ProductsEndpoints
{
    public static void MapProducts(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapCreateItem();
    }
}
