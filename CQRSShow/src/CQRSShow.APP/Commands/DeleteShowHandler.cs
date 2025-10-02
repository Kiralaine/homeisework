using CQRSShow.APP.Interfaces;
using MediatR;

namespace CQRSShow.APP.Commands;

public class DeleteShowHandler :IRequestHandler<DeleteShowCommand, long>
{
    private readonly IShowWriteRepository _repository;

    public DeleteShowHandler(IShowWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteShowCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}