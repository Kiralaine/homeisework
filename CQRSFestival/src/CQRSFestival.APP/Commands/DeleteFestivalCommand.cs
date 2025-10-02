using MediatR;

namespace CQRSFestival.APP.Commands;

public record DeleteFestivalCommand(long id) :IRequest<long>;