using CQRSSport.APP.Interfaces;
using MediatR;

namespace CQRSSport.APP.Commands;

public class DeleteSportHandler :IRequestHandler<DeleteSportCommand, long>
{
    private readonly ISportWriteRepository _repository;

    public DeleteSportHandler(ISportWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}