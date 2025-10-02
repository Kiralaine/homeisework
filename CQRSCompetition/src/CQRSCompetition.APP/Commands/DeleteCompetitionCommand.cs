using MediatR;

namespace CQRSCompetition.APP.Commands;

public record DeleteCompetitionCommand(long id) :IRequest<long>;