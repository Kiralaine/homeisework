using MediatR;

namespace CQRSSport.APP.Commands;

public record DeleteSportCommand(long id) :IRequest<long>;