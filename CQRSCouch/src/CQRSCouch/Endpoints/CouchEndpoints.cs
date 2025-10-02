using CQRSCouch.APP.Commands;
using CQRSCouch.APP.Dtos;
using CQRSCouch.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCouch.Endpoints;


[Route("api/couchs")]
[ApiController]
public class CouchEndpoints
{
     private readonly IMediator _mediator;
     public CouchEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<CouchDto>> GetAll()
     {
          var query = new GetAllCouchsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateCouchCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteCouchCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}