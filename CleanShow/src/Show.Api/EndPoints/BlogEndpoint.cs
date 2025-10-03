using Show.Application.Dtos;
using Show.Application.Service;

namespace Show.Api.EndPoints;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projects");

        group.MapGet("/", async (IShowService service) =>
        {
            var projects = await service.GetAllAsync();
            return projects;
        });

        group.MapGet("/{id:long}", async (long id, IShowService service) =>
        {
            var project = await service.GetByIdAsync(id);
            return project is not null ? Results.Ok(project) : Results.NotFound();
        });

        group.MapGet("/paged", async (int skip, int take, IShowService service) =>
        {
            var filter = new ShowFilterParams
            {
                Skip = skip,
                Take = take
            };

            var projects = await service.GetAllPagedAsync(filter);
            return Results.Ok(projects);
        });

        group.MapPost("/", async (ShowCreateDto dto, IShowService service) =>
        {
            await service.AddAsync(dto);
            return Results.Created($"/projects", dto);
        });

        group.MapPut("/{id:long}", async (long id, ShowUpdateDto dto, IShowService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.NoContent();
        });


        group.MapDelete("/{id:long}", async (long id, IShowService service) =>
        {
            await service.RemoveAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}
