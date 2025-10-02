using CQRSFestival.APP.Commands;
using CQRSFestival.APP.Dtos;
using CQRSFestival.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSFestival.Endpoints;


[Route("api/festivals")]
[ApiController]
public class FestivalEndpoints
{
     private readonly IMediator _mediator;
     public FestivalEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<FestivalDto>> GetAll()
     {
          var query = new GetAllFestivalsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateFestivalCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteFestivalCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}