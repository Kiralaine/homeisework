using CQRSCompetition.APP.Dtos;
using CQRSCompetition.APP.Interfaces;
using MediatR;

namespace CQRSCompetition.APP.Queries;

public class GetAllCompetitionsHandler : IRequestHandler<GetAllCompetitionsQuery, ICollection<CompetitionDto>>
{
    private readonly ICompetitionReadRepository _competitionReadRepository;

    public GetAllCompetitionsHandler(ICompetitionReadRepository competitionReadRepository)
    {
        _competitionReadRepository = competitionReadRepository;
    }

    public async Task<ICollection<CompetitionDto>> Handle(GetAllCompetitionsQuery request, CancellationToken cancellationToken)
    {
        var competitions = await _competitionReadRepository.GetAllAsync();
        var competitionsDtos = competitions.Select(p=>new CompetitionDto()
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
        return competitionsDtos;
    }
}