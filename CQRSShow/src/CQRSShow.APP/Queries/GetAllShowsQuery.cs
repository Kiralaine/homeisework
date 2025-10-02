using CQRSShow.APP.Dtos;
using MediatR;

namespace CQRSShow.APP.Queries;

public record GetAllShowsQuery() :IRequest<ICollection<ShowDto>>;
