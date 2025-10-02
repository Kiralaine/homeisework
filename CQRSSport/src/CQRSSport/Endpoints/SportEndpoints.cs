using CQRSSport.APP.Commands;
using CQRSSport.APP.Dtos;
using CQRSSport.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSSport.Endpoints;


[Route("api/sports")]
[ApiController]
public class SportEndpoints
{
     private readonly IMediator _mediator;
     public SportEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<SportDto>> GetAll()
     {
          var query = new GetAllSportsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateSportCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteSportCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}