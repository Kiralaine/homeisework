using CQRSFestival.APP.Dtos;
using CQRSFestival.APP.Interfaces;
using MediatR;

namespace CQRSFestival.APP.Queries;

public class GetAllFestivalsHandler : IRequestHandler<GetAllFestivalsQuery, ICollection<FestivalDto>>
{
    private readonly IFestivalReadRepository _festivalReadRepository;

    public GetAllFestivalsHandler(IFestivalReadRepository festivalReadRepository)
    {
        _festivalReadRepository = festivalReadRepository;
    }

    public async Task<ICollection<FestivalDto>> Handle(GetAllFestivalsQuery request, CancellationToken cancellationToken)
    {
        var festivals = await _festivalReadRepository.GetAllAsync();
        var festivalsDtos = festivals.Select(p=>new FestivalDto()
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
        return festivalsDtos;
    }
}