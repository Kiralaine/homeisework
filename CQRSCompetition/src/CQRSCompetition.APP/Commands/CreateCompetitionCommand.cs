using MediatR;

namespace CQRSCompetition.APP.Commands;

public record CreateCompetitionCommand(
     string FirstName,
     string LastName,
     int Age,
     string Gender,
     string Sport,
     string Team,
     string Position, 
     string Nationality, 
     string Height, 
     string Weight
) : IRequest<long>;