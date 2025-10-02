using CQRSReferee.APP.Dtos;
using CQRSReferee.APP.Interfaces;
using MediatR;

namespace CQRSReferee.APP.Queries;

public class GetAllRefereesHandler : IRequestHandler<GetAllRefereesQuery, ICollection<RefereeDto>>
{
    private readonly IRefereeReadRepository _refereeReadRepository;

    public GetAllRefereesHandler(IRefereeReadRepository refereeReadRepository)
    {
        _refereeReadRepository = refereeReadRepository;
    }

    public async Task<ICollection<RefereeDto>> Handle(GetAllRefereesQuery request, CancellationToken cancellationToken)
    {
        var referees = await _refereeReadRepository.GetAllAsync();
        var refereesDtos = referees.Select(p=>new RefereeDto()
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
        return refereesDtos;
    }
}