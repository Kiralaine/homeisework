using Competition.Application.Dtos;
using Competition.Application.Service;

namespace Competition.Api.EndPoints;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projects");

        group.MapGet("/", async (ICompetitionService service) =>
        {
            var projects = await service.GetAllAsync();
            return projects;
        });

        group.MapGet("/{id:long}", async (long id, ICompetitionService service) =>
        {
            var project = await service.GetByIdAsync(id);
            return project is not null ? Results.Ok(project) : Results.NotFound();
        });

        group.MapGet("/paged", async (int skip, int take, ICompetitionService service) =>
        {
            var filter = new CompetitionFilterParams
            {
                Skip = skip,
                Take = take
            };

            var projects = await service.GetAllPagedAsync(filter);
            return Results.Ok(projects);
        });

        group.MapPost("/", async (CompetitionCreateDto dto, ICompetitionService service) =>
        {
            await service.AddAsync(dto);
            return Results.Created($"/projects", dto);
        });

        group.MapPut("/{id:long}", async (long id, CompetitionUpdateDto dto, ICompetitionService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.NoContent();
        });


        group.MapDelete("/{id:long}", async (long id, ICompetitionService service) =>
        {
            await service.RemoveAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}
