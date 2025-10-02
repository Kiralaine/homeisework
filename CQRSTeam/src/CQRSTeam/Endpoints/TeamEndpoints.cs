using CQRSTeam.APP.Commands;
using CQRSTeam.APP.Dtos;
using CQRSTeam.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTeam.Endpoints;


[Route("api/teams")]
[ApiController]
public class TeamEndpoints
{
     private readonly IMediator _mediator;
     public TeamEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<TeamDto>> GetAll()
     {
          var query = new GetAllTeamsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateTeamCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteTeamCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}