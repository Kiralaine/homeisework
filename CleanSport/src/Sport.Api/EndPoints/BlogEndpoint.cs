using Sport.Application.Dtos;
using Sport.Application.Service;

namespace Sport.Api.EndPoints;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projects");

        group.MapGet("/", async (ISportService service) =>
        {
            var projects = await service.GetAllAsync();
            return projects;
        });

        group.MapGet("/{id:long}", async (long id, ISportService service) =>
        {
            var project = await service.GetByIdAsync(id);
            return project is not null ? Results.Ok(project) : Results.NotFound();
        });

        group.MapGet("/paged", async (int skip, int take, ISportService service) =>
        {
            var filter = new SportFilterParams
            {
                Skip = skip,
                Take = take
            };

            var projects = await service.GetAllPagedAsync(filter);
            return Results.Ok(projects);
        });

        group.MapPost("/", async (SportCreateDto dto, ISportService service) =>
        {
            await service.AddAsync(dto);
            return Results.Created($"/projects", dto);
        });

        group.MapPut("/{id:long}", async (long id, SportUpdateDto dto, ISportService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.NoContent();
        });


        group.MapDelete("/{id:long}", async (long id, ISportService service) =>
        {
            await service.RemoveAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}
