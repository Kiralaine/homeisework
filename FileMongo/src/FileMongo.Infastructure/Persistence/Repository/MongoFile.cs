using FileMongo.App.Interfaces;
using FileMongo.Domain;
using MongoDB.Driver;

namespace FileMongo.Infastructure.Persistence.Repository;

public class MongoFile : IMongoFile
{
    private readonly IMongoCollection<File> _collection;

    public MongoFile(IMongoCollection<File> collection)
    {
        _collection = collection;
    }

    public async Task<List<File>> GetFiles()
    {
         var cursor=  await  _collection.Find(file => true).ToListAsync();
         return cursor;
         
    }

    public Task<File> GetFile(long id)
    {
        var cursor = _collection.Find(file => file.Id == id);
        return cursor.FirstOrDefaultAsync();
    }

    public async Task<long> AddFile(File file)
    {
        if (file.Id == 0)
            file.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _collection.InsertOne(file); 
        return file.Id;
    }

    public async Task DeleteFile(File file)
    {
        _collection.DeleteOne(file => file.Id == file.Id);
    }
}