using CQRSTeam.APP.Interfaces;
using MediatR;

namespace CQRSTeam.APP.Commands;

public class DeleteTeamHandler :IRequestHandler<DeleteTeamCommand, long>
{
    private readonly ITeamWriteRepository _repository;

    public DeleteTeamHandler(ITeamWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}