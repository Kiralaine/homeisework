using BookMongo.App.Interfaces;
using BookMongo.Domain;
using MongoDB.Driver;

namespace BookMongo.Infastructure.Persistence.Repository;

public class MongoBook : IMongoBook
{
    private readonly IMongoCollection<Book> _collection;

    public MongoBook(IMongoCollection<Book> collection)
    {
        _collection = collection;
    }

    public async Task<List<Book>> GetBooks()
    {
         var cursor=  await  _collection.Find(book => true).ToListAsync();
         return cursor;
         
    }

    public Task<Book> GetBook(long id)
    {
        var cursor = _collection.Find(book => book.Id == id);
        return cursor.FirstOrDefaultAsync();
    }

    public async Task<long> AddBook(Book book)
    {
        if (book.Id == 0)
            book.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        _collection.InsertOne(book); 
        return book.Id;
    }

    public async Task DeleteBook(Book book)
    {
        _collection.DeleteOne(book => book.Id == book.Id);
    }
}