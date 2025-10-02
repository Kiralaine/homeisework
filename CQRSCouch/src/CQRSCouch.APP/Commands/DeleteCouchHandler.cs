using CQRSCouch.APP.Interfaces;
using MediatR;

namespace CQRSCouch.APP.Commands;

public class DeleteCouchHandler :IRequestHandler<DeleteCouchCommand, long>
{
    private readonly ICouchWriteRepository _repository;

    public DeleteCouchHandler(ICouchWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteCouchCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}