using CQRSSeason.APP.Interfaces;
using CQRSSeason.Domain.Entities;
using MediatR;

namespace CQRSSeason.APP.Commands;

public class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, long>
{
    private readonly ISeasonWriteRepository _repository;

    public CreateSeasonHandler(ISeasonWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        var entity = new Season
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
        var seasonID = await  _repository.AddAsync(entity);
        return seasonID;
        
    }
}