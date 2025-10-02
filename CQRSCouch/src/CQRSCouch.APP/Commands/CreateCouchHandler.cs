using CQRSCouch.APP.Interfaces;
using CQRSCouch.Domain.Entities;
using MediatR;

namespace CQRSCouch.APP.Commands;

public class CreateCouchHandler : IRequestHandler<CreateCouchCommand, long>
{
    private readonly ICouchWriteRepository _repository;

    public CreateCouchHandler(ICouchWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateCouchCommand request, CancellationToken cancellationToken)
    {
        var entity = new Couch
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
        var couchID = await  _repository.AddAsync(entity);
        return couchID;
        
    }
}