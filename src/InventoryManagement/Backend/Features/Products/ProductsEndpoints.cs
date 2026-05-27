using Backend.Features.Products.CreateProduct;
using Backend.Features.Products.DeleteProduct;
using Backend.Features.Products.GetProduct;
using Backend.Features.Products.GetProducts;
using Backend.Features.Products.UpdateProduct;

namespace Backend.Features.Products;

public static class ProductsEndpoints
{
    public static void MapProducts(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapCreateProduct();
        group.MapGetProduct();
        group.MapGetProducts();
        group.MapUpdateProduct();
        group.MapDeleteProduct();
    }
}
