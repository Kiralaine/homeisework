using CQRSSport.APP.Dtos;
using MediatR;

namespace CQRSSport.APP.Queries;

public record GetAllSportsQuery() :IRequest<ICollection<SportDto>>;
