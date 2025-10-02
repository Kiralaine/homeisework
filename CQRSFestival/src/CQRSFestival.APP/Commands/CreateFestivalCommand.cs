using MediatR;

namespace CQRSFestival.APP.Commands;

public record CreateFestivalCommand(
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