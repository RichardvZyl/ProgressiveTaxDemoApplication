using Abstractions.Generics;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApplication.DAL;

public interface IUserRepository : IGenericRepository<User, Guid> 
{
    Task<User> GetByEmail(string email);
}

public sealed class UserRepository : IUserRepository
{
    public UserRepository()
    {

    }

    public async Task<Guid> CreateAsync(User model) 
        => throw new NotImplementedException();

    public async Task<User> GetByIdAsync(Guid id) 
        => throw new NotImplementedException();

    public async Task<IEnumerable<User>> ListAsync() 
        => throw new NotImplementedException();

    public async Task<bool> UpdateAsync(User model) 
        => throw new NotImplementedException();

    public async Task<bool> DeleteAsync(Guid id) 
        => throw new NotImplementedException();

    public async Task<IDictionary<Guid, User>> GetTableAsync() 
        => throw new NotImplementedException();
    
    public Task<User> GetByEmail(string email) 
        => throw new NotImplementedException();
}
