using System.Data;
using Abstractions.AspNetCore;
using Abstractions.Generics;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApplication.DAL;

public interface IUserRepository : IGenericRepository<User, Guid>
{
    Task<User?> GetByEmail(string email);
}

public sealed class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IServiceCollection services)
        => _connectionString = ServiceExtensions.GetConnectionString(services, nameof(ProgressiveTaxDatabaase));

    public async Task<Guid> CreateAsync(User model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var sqlCommand = @$"INSERT INTO dbo.{nameof(User)}
                                   (Rate, From, LastUpdated) 
                                   VALUES(@Rate, @From, @LastUpdated)";

            _ = await connection.ExecuteAsync(sqlCommand, model);

            return model.Id;
        }
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, Email, PostalCode, Salary, LastUpdated
                                FROM dbo.{nameof(User)}
                                WHERE Id = @id";

            return (await connection.QueryAsync<User>(query, id)).FirstOrDefault();
        }
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, Rate, From, LastUpdated
                                FROM dbo.{nameof(User)}";

            return await connection.QueryAsync<User>(query) ?? new List<User>();
        }
    }

    public async Task<bool> UpdateAsync(User model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"UPDATE dbo.{nameof(User)}
                                Rate = @Rate, From = @From, LastUpdated = @LastUpdated
                                WHERE Id = @Id";

            return await connection.ExecuteAsync(query, model) == 1;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"DELETE FROM dbo.{nameof(User)}
                                WHERE Id = @id";

            return await connection.ExecuteAsync(query, id) == 1;
        }
    }

    public async Task<User?> GetByEmail(string email)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, Email, PostalCode, Salary, LastUpdated
                                FROM dbo.{nameof(User)}
                                WHERE Email = @email";

            return (await connection.QueryAsync<User>(query, email)).FirstOrDefault();
        }
    }

    public Task<IDictionary<Guid, User>> GetTableAsync() 
        => throw new NotImplementedException(); //KISS
}
