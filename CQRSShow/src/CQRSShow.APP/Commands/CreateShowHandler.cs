using CQRSShow.APP.Interfaces;
using CQRSShow.Domain.Entities;
using MediatR;

namespace CQRSShow.APP.Commands;

public class CreateShowHandler : IRequestHandler<CreateShowCommand, long>
{
    private readonly IShowWriteRepository _repository;

    public CreateShowHandler(IShowWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(CreateShowCommand request, CancellationToken cancellationToken)
    {
        var entity = new Show
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
        var showID = await  _repository.AddAsync(entity);
        return showID;
        
    }
}