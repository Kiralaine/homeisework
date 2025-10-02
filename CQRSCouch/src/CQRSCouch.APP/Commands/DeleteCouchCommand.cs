using MediatR;

namespace CQRSCouch.APP.Commands;

public record DeleteCouchCommand(long id) :IRequest<long>;