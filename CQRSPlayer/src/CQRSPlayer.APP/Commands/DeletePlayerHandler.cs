using CQRSPlayer.APP.Interfaces;
using MediatR;

namespace CQRSPlayer.APP.Commands;

public class DeletePlayerHandler :IRequestHandler<DeletePlayerCommand, long>
{
    private readonly IPlayerWriteRepository _repository;

    public DeletePlayerHandler(IPlayerWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}