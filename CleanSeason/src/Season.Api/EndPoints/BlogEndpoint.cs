using Season.Application.Dtos;
using Season.Application.Service;

namespace Season.Api.EndPoints;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projects");

        group.MapGet("/", async (ISeasonService service) =>
        {
            var projects = await service.GetAllAsync();
            return projects;
        });

        group.MapGet("/{id:long}", async (long id, ISeasonService service) =>
        {
            var project = await service.GetByIdAsync(id);
            return project is not null ? Results.Ok(project) : Results.NotFound();
        });

        group.MapGet("/paged", async (int skip, int take, ISeasonService service) =>
        {
            var filter = new SeasonFilterParams
            {
                Skip = skip,
                Take = take
            };

            var projects = await service.GetAllPagedAsync(filter);
            return Results.Ok(projects);
        });

        group.MapPost("/", async (SeasonCreateDto dto, ISeasonService service) =>
        {
            await service.AddAsync(dto);
            return Results.Created($"/projects", dto);
        });

        group.MapPut("/{id:long}", async (long id, SeasonUpdateDto dto, ISeasonService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.NoContent();
        });


        group.MapDelete("/{id:long}", async (long id, ISeasonService service) =>
        {
            await service.RemoveAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}
