using CQRSTeam.APP.Interfaces;
using CQRSTeam.Domain.Entities;
using MediatR;

namespace CQRSTeam.APP.Commands;

public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, long>
{
    private readonly ITeamWriteRepository _repository;

    public CreateTeamHandler(ITeamWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var entity = new Team
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
        var teamID = await  _repository.AddAsync(entity);
        return teamID;
        
    }
}