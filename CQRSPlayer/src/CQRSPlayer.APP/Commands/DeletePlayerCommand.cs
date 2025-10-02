using MediatR;

namespace CQRSPlayer.APP.Commands;

public record DeletePlayerCommand(long id) :IRequest<long>;