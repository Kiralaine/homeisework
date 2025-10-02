using CQRSTeam.APP.Dtos;
using MediatR;

namespace CQRSTeam.APP.Queries;

public record GetAllTeamsQuery() :IRequest<ICollection<TeamDto>>;
