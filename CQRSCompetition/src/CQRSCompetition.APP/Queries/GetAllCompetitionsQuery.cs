using CQRSCompetition.APP.Dtos;
using MediatR;

namespace CQRSCompetition.APP.Queries;

public record GetAllCompetitionsQuery() :IRequest<ICollection<CompetitionDto>>;
