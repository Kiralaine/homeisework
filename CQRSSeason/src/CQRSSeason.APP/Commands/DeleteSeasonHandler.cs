using CQRSSeason.APP.Interfaces;
using MediatR;

namespace CQRSSeason.APP.Commands;

public class DeleteSeasonHandler :IRequestHandler<DeleteSeasonCommand, long>
{
    private readonly ISeasonWriteRepository _repository;

    public DeleteSeasonHandler(ISeasonWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteSeasonCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}