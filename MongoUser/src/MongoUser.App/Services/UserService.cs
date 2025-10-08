using MongoUser.App.Interfaces;
using MongoUser.Domain;

namespace MongoUser.App.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async  Task<List<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        await _userRepository.DeleteAsync(user);
    }
}