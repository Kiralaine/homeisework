using SportMongo.Domain;

namespace SportMongo.App.Interfaces;

public interface IMongoSport
{
    Task<List<Sport>> GetSports();
    Task<Sport> GetSport( long id);
    Task<long> AddSport(Sport sport);
    Task DeleteSport(Sport sport);
    
    
}