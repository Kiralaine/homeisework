using BookMongo.Domain;

namespace BookMongo.App.Interfaces;

public interface IMongoBook
{
    Task<List<Book>> GetBooks();
    Task<Book> GetBook( long id);
    Task<long> AddBook(Book book);
    Task DeleteBook(Book book);
    
    
}