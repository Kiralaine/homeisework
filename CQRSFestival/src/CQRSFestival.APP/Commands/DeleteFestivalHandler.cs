using CQRSFestival.APP.Interfaces;
using MediatR;

namespace CQRSFestival.APP.Commands;

public class DeleteFestivalHandler :IRequestHandler<DeleteFestivalCommand, long>
{
    private readonly IFestivalWriteRepository _repository;

    public DeleteFestivalHandler(IFestivalWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteFestivalCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}