using CQRSReferee.APP.Dtos;
using MediatR;

namespace CQRSReferee.APP.Queries;

public record GetAllRefereesQuery() :IRequest<ICollection<RefereeDto>>;
