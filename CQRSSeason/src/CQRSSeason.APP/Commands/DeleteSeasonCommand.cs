using MediatR;

namespace CQRSSeason.APP.Commands;

public record DeleteSeasonCommand(long id) :IRequest<long>;