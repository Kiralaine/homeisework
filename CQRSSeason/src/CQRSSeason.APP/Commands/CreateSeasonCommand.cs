using MediatR;

namespace CQRSSeason.APP.Commands;

public record CreateSeasonCommand(
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