using CQRSFestival.APP.Interfaces;
using CQRSFestival.Domain.Entities;
using MediatR;

namespace CQRSFestival.APP.Commands;

public class CreateFestivalHandler : IRequestHandler<CreateFestivalCommand, long>
{
    private readonly IFestivalWriteRepository _repository;

    public CreateFestivalHandler(IFestivalWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateFestivalCommand request, CancellationToken cancellationToken)
    {
        var entity = new Festival
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
        var festivalID = await  _repository.AddAsync(entity);
        return festivalID;
        
    }
}