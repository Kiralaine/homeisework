using Festival.Application.Dtos;
using Festival.Application.Service;

namespace Festival.Api.EndPoints;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projects");

        group.MapGet("/", async (IFestivalService service) =>
        {
            var projects = await service.GetAllAsync();
            return projects;
        });

        group.MapGet("/{id:long}", async (long id, IFestivalService service) =>
        {
            var project = await service.GetByIdAsync(id);
            return project is not null ? Results.Ok(project) : Results.NotFound();
        });

        group.MapGet("/paged", async (int skip, int take, IFestivalService service) =>
        {
            var filter = new FestivalFilterParams
            {
                Skip = skip,
                Take = take
            };

            var projects = await service.GetAllPagedAsync(filter);
            return Results.Ok(projects);
        });

        group.MapPost("/", async (FestivalCreateDto dto, IFestivalService service) =>
        {
            await service.AddAsync(dto);
            return Results.Created($"/projects", dto);
        });

        group.MapPut("/{id:long}", async (long id, FestivalUpdateDto dto, IFestivalService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.NoContent();
        });


        group.MapDelete("/{id:long}", async (long id, IFestivalService service) =>
        {
            await service.RemoveAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}
