using CQRSPlayer.APP.Dtos;
using MediatR;

namespace CQRSPlayer.APP.Queries;

public record GetAllPlayersQuery() :IRequest<ICollection<PlayerDto>>;
