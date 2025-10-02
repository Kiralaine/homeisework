using CQRSCompetition.APP.Interfaces;
using MediatR;

namespace CQRSCompetition.APP.Commands;

public class DeleteCompetitionHandler :IRequestHandler<DeleteCompetitionCommand, long>
{
    private readonly ICompetitionWriteRepository _repository;

    public DeleteCompetitionHandler(ICompetitionWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteCompetitionCommand request, CancellationToken cancellationToken)
    {
         await _repository.DeleteAsync(request.id);
         return request.id;
    }
}