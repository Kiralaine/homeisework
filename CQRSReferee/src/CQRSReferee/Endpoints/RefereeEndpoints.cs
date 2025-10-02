using CQRSReferee.APP.Commands;
using CQRSReferee.APP.Dtos;
using CQRSReferee.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSReferee.Endpoints;


[Route("api/referees")]
[ApiController]
public class RefereeEndpoints
{
     private readonly IMediator _mediator;
     public RefereeEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<RefereeDto>> GetAll()
     {
          var query = new GetAllRefereesQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateRefereeCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteRefereeCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}