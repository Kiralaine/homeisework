using CQRSCouch.APP.Dtos;
using CQRSCouch.APP.Interfaces;
using MediatR;

namespace CQRSCouch.APP.Queries;

public class GetAllCouchsHandler : IRequestHandler<GetAllCouchsQuery, ICollection<CouchDto>>
{
    private readonly ICouchReadRepository _couchReadRepository;

    public GetAllCouchsHandler(ICouchReadRepository couchReadRepository)
    {
        _couchReadRepository = couchReadRepository;
    }

    public async Task<ICollection<CouchDto>> Handle(GetAllCouchsQuery request, CancellationToken cancellationToken)
    {
        var couchs = await _couchReadRepository.GetAllAsync();
        var couchsDtos = couchs.Select(p=>new CouchDto()
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
        return couchsDtos;
    }
}