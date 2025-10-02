using CQRSSport.APP.Interfaces;
using CQRSSport.Domain.Entities;
using MediatR;

namespace CQRSSport.APP.Commands;

public class CreateSportHandler : IRequestHandler<CreateSportCommand, long>
{
    private readonly ISportWriteRepository _repository;

    public CreateSportHandler(ISportWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateSportCommand request, CancellationToken cancellationToken)
    {
        var entity = new Sport
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
        var sportID = await  _repository.AddAsync(entity);
        return sportID;
        
    }
}