using CQRSCouch.APP.Dtos;
using MediatR;

namespace CQRSCouch.APP.Queries;

public record GetAllCouchsQuery() :IRequest<ICollection<CouchDto>>;
