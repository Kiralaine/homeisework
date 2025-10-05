using SportMongo.App.Interfaces;
using SportMongo.Domain;
using MongoDB.Driver;

namespace SportMongo.Infastructure.Persistence.Repository;

public class MongoSport : IMongoSport
{
    private readonly IMongoCollection<Sport> _collection;

    public MongoSport(IMongoCollection<Sport> collection)
    {
        _collection = collection;
    }

    public async Task<List<Sport>> GetSports()
    {
         var cursor=  await  _collection.Find(sport => true).ToListAsync();
         return cursor;
         
    }

    public Task<Sport> GetSport(long id)
    {
        var cursor = _collection.Find(sport => sport.Id == id);
        return cursor.FirstOrDefaultAsync();
    }

    public async Task<long> AddSport(Sport sport)
    {
        if (sport.Id == 0)
            sport.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _collection.InsertOne(sport); 
        return sport.Id;
    }

    public async Task DeleteSport(Sport sport)
    {
        _collection.DeleteOne(sport => sport.Id == sport.Id);
    }
}