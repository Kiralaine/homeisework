using MediatR;

namespace CQRSShow.APP.Commands;

public record CreateShowCommand(
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