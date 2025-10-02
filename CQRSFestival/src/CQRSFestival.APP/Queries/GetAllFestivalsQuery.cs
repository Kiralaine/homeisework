using CQRSFestival.APP.Dtos;
using MediatR;

namespace CQRSFestival.APP.Queries;

public record GetAllFestivalsQuery() :IRequest<ICollection<FestivalDto>>;
