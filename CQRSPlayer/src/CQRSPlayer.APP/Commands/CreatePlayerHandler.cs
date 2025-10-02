using CQRSPlayer.APP.Interfaces;
using CQRSPlayer.Domain.Entities;
using MediatR;

namespace CQRSPlayer.APP.Commands;

public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, long>
{
    private readonly IPlayerWriteRepository _repository;

    public CreatePlayerHandler(IPlayerWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Player
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
        var playerID = await  _repository.AddAsync(entity);
        return playerID;
        
    }
}