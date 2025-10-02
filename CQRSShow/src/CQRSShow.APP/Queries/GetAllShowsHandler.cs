using CQRSShow.APP.Dtos;
using CQRSShow.APP.Interfaces;
using MediatR;

namespace CQRSShow.APP.Queries;

public class GetAllShowsHandler : IRequestHandler<GetAllShowsQuery, ICollection<ShowDto>>
{
    private readonly IShowReadRepository _showReadRepository;

    public GetAllShowsHandler(IShowReadRepository showReadRepository)
    {
        _showReadRepository = showReadRepository;
    }

    public async Task<ICollection<ShowDto>> Handle(GetAllShowsQuery request, CancellationToken cancellationToken)
    {
        var shows = await _showReadRepository.GetAllAsync();
        var showsDtos = shows.Select(p=>new ShowDto()
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
        return showsDtos;
    }
}