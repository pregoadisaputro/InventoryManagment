using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Categories.GetCategories;

public static class GetCategoriesEndpoint
{
    public static void MapGetCategories(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/",
            async (InventoryDbContext dbContext) =>
            {
                await dbContext
                    .Categories.Select(category => new GetCategoriesDto(category.Id, category.Name))
                    .AsNoTracking()
                    .ToListAsync();
            }
        );
    }
}
