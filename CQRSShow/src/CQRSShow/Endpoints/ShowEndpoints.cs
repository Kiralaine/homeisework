using CQRSShow.APP.Commands;
using CQRSShow.APP.Dtos;
using CQRSShow.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSShow.Endpoints;


[Route("api/shows")]
[ApiController]
public class ShowEndpoints
{
     private readonly IMediator _mediator;
     public ShowEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<ShowDto>> GetAll()
     {
          var query = new GetAllShowsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateShowCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteShowCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}