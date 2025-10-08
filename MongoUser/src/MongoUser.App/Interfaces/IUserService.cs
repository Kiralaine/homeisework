using MongoUser.Domain;

namespace MongoUser.App.Interfaces;

public interface IUserService
{
    Task<User> GetByIdAsync(long id);
    Task<List<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task DeleteAsync(long id);
}