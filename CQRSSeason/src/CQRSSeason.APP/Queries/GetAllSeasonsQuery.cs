using CQRSSeason.APP.Dtos;
using MediatR;

namespace CQRSSeason.APP.Queries;

public record GetAllSeasonsQuery() :IRequest<ICollection<SeasonDto>>;
