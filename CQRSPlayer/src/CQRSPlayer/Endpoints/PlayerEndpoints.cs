using CQRSPlayer.APP.Commands;
using CQRSPlayer.APP.Dtos;
using CQRSPlayer.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPlayer.Endpoints;


[Route("api/players")]
[ApiController]
public class PlayerEndpoints
{
     private readonly IMediator _mediator;
     public PlayerEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<PlayerDto>> GetAll()
     {
          var query = new GetAllPlayersQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreatePlayerCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeletePlayerCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}