using CQRSCompetition.APP.Interfaces;
using CQRSCompetition.Domain.Entities;
using MediatR;

namespace CQRSCompetition.APP.Commands;

public class CreateCompetitionHandler : IRequestHandler<CreateCompetitionCommand, long>
{
    private readonly ICompetitionWriteRepository _repository;

    public CreateCompetitionHandler(ICompetitionWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateCompetitionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Competition
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
        var competitionID = await  _repository.AddAsync(entity);
        return competitionID;
        
    }
}