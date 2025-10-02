using CQRSReferee.APP.Interfaces;
using CQRSReferee.Domain.Entities;
using MediatR;

namespace CQRSReferee.APP.Commands;

public class CreateRefereeHandler : IRequestHandler<CreateRefereeCommand, long>
{
    private readonly IRefereeWriteRepository _repository;

    public CreateRefereeHandler(IRefereeWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateRefereeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Referee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Height = request.Height,
            Weight = request.Weight,
            Age = request.Age,
            Position = request.Position,
            Sport = request.Sport,
            Gender = request.Gender,
            Nationality = request.Nationality,
            Team = request.Team
        };
        var refereeID = await  _repository.AddAsync(entity);
        return refereeID;
        
    }
}