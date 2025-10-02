using MediatR;

namespace CQRSTeam.APP.Commands;

public record DeleteTeamCommand(long id) :IRequest<long>;