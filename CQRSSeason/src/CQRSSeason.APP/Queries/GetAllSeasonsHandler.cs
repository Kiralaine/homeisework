using CQRSSeason.APP.Dtos;
using CQRSSeason.APP.Interfaces;
using MediatR;

namespace CQRSSeason.APP.Queries;

public class GetAllSeasonsHandler : IRequestHandler<GetAllSeasonsQuery, ICollection<SeasonDto>>
{
    private readonly ISeasonReadRepository _seasonReadRepository;

    public GetAllSeasonsHandler(ISeasonReadRepository seasonReadRepository)
    {
        _seasonReadRepository = seasonReadRepository;
    }

    public async Task<ICollection<SeasonDto>> Handle(GetAllSeasonsQuery request, CancellationToken cancellationToken)
    {
        var seasons = await _seasonReadRepository.GetAllAsync();
        var seasonsDtos = seasons.Select(p=>new SeasonDto()
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
        return seasonsDtos;
    }
}