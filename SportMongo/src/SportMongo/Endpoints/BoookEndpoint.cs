using SportMongo.App.Interfaces;
using SportMongo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace SportMongo.Endpoints;

[Route("api/sports")]
[ApiController]
public class BoookEndpoint
{
    private readonly IMongoSport _mongoSport;

    [HttpPost]
    public async Task<long> AddSport(Sport sport)
    {
        await _mongoSport.AddSport(sport);
        return sport.Id;
    }

    [HttpGet]
    public async Task<List<Sport>> GetSports()
    {
        return await _mongoSport.GetSports();
    }

    [HttpGet("{id}")]
    public async Task<Sport> GetSport(long id)
    {
        return await _mongoSport.GetSport(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteSport(long id)
    {
        var sport = await _mongoSport.GetSport(id);
        await _mongoSport.DeleteSport(sport);
    }
}