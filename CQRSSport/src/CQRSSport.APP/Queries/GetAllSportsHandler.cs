using CQRSSport.APP.Dtos;
using CQRSSport.APP.Interfaces;
using MediatR;

namespace CQRSSport.APP.Queries;

public class GetAllSportsHandler : IRequestHandler<GetAllSportsQuery, ICollection<SportDto>>
{
    private readonly ISportReadRepository _sportReadRepository;

    public GetAllSportsHandler(ISportReadRepository sportReadRepository)
    {
        _sportReadRepository = sportReadRepository;
    }

    public async Task<ICollection<SportDto>> Handle(GetAllSportsQuery request, CancellationToken cancellationToken)
    {
        var sports = await _sportReadRepository.GetAllAsync();
        var sportsDtos = sports.Select(p=>new SportDto()
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
        return sportsDtos;
    }
}