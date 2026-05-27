using Backend.Features.Categories.GetCategories;

namespace Backend.Features.Categories;

public static class CategoriesEndpoints
{
    public static void MapCategories(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/categories");

        group.MapGetCategories();
    }
}
