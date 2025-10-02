using CQRSCompetition.APP.Commands;
using CQRSCompetition.APP.Dtos;
using CQRSCompetition.APP.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCompetition.Endpoints;


[Route("api/competitions")]
[ApiController]
public class CompetitionEndpoints
{
     private readonly IMediator _mediator;
     public CompetitionEndpoints(IMediator mediator) => _mediator = mediator;

     [HttpGet]
     public async Task<ICollection<CompetitionDto>> GetAll()
     {
          var query = new GetAllCompetitionsQuery();
          return await _mediator.Send(query);
          
     }

     [HttpPost]
     public async Task<long> Post(CreateCompetitionCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }

     [HttpDelete]
     public async Task<long> Delete(DeleteCompetitionCommand command)
     {
          var result = await _mediator.Send(command);
          return result;
     }
}