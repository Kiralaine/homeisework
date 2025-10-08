using MongoUser.Domain;

namespace MongoUser.App.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<long> AddAsync(User user);
    Task DeleteAsync(User user);
    Task<User> GetByIdAsync(long id);
}