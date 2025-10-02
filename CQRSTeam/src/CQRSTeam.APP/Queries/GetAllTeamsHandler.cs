using CQRSTeam.APP.Dtos;
using CQRSTeam.APP.Interfaces;
using MediatR;

namespace CQRSTeam.APP.Queries;

public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, ICollection<TeamDto>>
{
    private readonly ITeamReadRepository _teamReadRepository;

    public GetAllTeamsHandler(ITeamReadRepository teamReadRepository)
    {
        _teamReadRepository = teamReadRepository;
    }

    public async Task<ICollection<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamReadRepository.GetAllAsync();
        var teamsDtos = teams.Select(p=>new TeamDto()
        {
           
            FirstName = p.FirstName,
            LastName = p.LastName,
            Nationality = p.Nationality,
            Team = p.Team,
            Gender = p.Gender,
            Sport = p.Sport,
            Weight =  p.Weight,
            Height = p.Height,
            Position = p.Position,
            Age = p.Age
        }).ToList();
        return teamsDtos;
    }
}