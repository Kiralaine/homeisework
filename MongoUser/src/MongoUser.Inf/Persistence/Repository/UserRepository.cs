using MongoDB.Driver;
using MongoUser.App.Interfaces;
using MongoUser.Domain;

namespace MongoUser.Inf.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMongoCollection<User> users)
    {
        _users = users;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _users.Find(FilterDefinition<User>.Empty).ToListAsync();
    }

    public async Task<long> AddAsync(User user)
    {
        if (user.Id == 0)
            user.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        await _users.InsertOneAsync(user);
        return user.Id;
    }

    public Task DeleteAsync(User user)
    {
        _users.DeleteOne(x => x.Id == user.Id);
        return Task.CompletedTask;
    }

    public Task<User> GetByIdAsync(long id)
    {
       return _users.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}