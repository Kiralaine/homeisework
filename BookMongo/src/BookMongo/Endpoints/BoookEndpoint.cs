using BookMongo.App.Interfaces;
using BookMongo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookMongo.Endpoints;

[Route("api/books")]
[ApiController]
public class BoookEndpoint
{
    private readonly IMongoBook _mongoBook;

    [HttpPost]
    public async Task<long> AddBook(Book book)
    {
        await _mongoBook.AddBook(book);
        return book.Id;
    }

    [HttpGet]
    public async Task<List<Book>> GetBooks()
    {
        return await _mongoBook.GetBooks();
    }

    [HttpGet("{id}")]
    public async Task<Book> GetBook(long id)
    {
        return await _mongoBook.GetBook(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteBook(long id)
    {
        var book = await _mongoBook.GetBook(id);
        await _mongoBook.DeleteBook(book);
    }
}