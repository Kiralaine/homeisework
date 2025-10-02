using MediatR;

namespace CQRSShow.APP.Commands;

public record DeleteShowCommand(long id) :IRequest<long>;