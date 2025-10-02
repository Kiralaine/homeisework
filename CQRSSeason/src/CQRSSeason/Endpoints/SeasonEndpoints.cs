using CQRSSeason.APP.Commands;
using CQRSSeason.APP.Dtos;
using CQRSSeason.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSSeason.Endpoints;


[Route("api/seasons")]
[ApiController]
public class SeasonEndpoints
{
     private readonly IMediator _mediator;
     public SeasonEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<SeasonDto>> GetAll()
     {
          var query = new GetAllSeasonsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateSeasonCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteSeasonCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}