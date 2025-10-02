using MediatR;

namespace CQRSReferee.APP.Commands;

public record DeleteRefereeCommand(long id) :IRequest<long>;