using CQRSReferee.APP.Interfaces;
using MediatR;

namespace CQRSReferee.APP.Commands;

public class DeleteRefereeHandler :IRequestHandler<DeleteRefereeCommand, long>
{
    private readonly IRefereeWriteRepository _repository;

    public DeleteRefereeHandler(IRefereeWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteRefereeCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}