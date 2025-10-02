using MediatR;

namespace CQRSTeam.APP.Commands;

public record CreateTeamCommand(
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