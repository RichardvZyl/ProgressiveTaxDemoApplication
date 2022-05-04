using System.Data;
using Abstractions.AspNetCore;
using Abstractions.Generics;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApplication.DAL;

public interface IProgressiveTaxRepository : IGenericRepository<ProgressiveTax, int> { }

public sealed class ProgressiveTaxRepository : IProgressiveTaxRepository
{
    private readonly string _connectionString;

    public ProgressiveTaxRepository(IServiceCollection services)
        => _connectionString = ServiceExtensions.GetConnectionString(services, nameof(ProgressiveTaxDatabaase));


    public async Task<int> CreateAsync(ProgressiveTax model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var sqlCommand = @$"INSERT INTO dbo.{nameof(ProgressiveTax)}
                                   (Rate, From, LastUpdated) 
                                   VALUES(@Rate, @From, @LastUpdated)";

            _ = await connection.ExecuteAsync(sqlCommand, model);

            return model.Id;
        }
    }

    public async Task<ProgressiveTax?> GetByIdAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, Rate, From, LastUpdated
                                FROM dbo.{nameof(ProgressiveTax)}
                                WHERE Id = @id";

            return (await connection.QueryAsync<ProgressiveTax>(query, id)).FirstOrDefault();
        }
    }

    public async Task<IEnumerable<ProgressiveTax>> ListAsync()
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, Rate, From, LastUpdated
                                FROM dbo.{nameof(ProgressiveTax)}";

            return await connection.QueryAsync<ProgressiveTax>(query) ?? new List<ProgressiveTax>();
        }
    }

    public async Task<bool> UpdateAsync(ProgressiveTax model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"UPDATE dbo.{nameof(ProgressiveTax)}
                                Rate = @Rate, From = @From, LastUpdated = @LastUpdated
                                WHERE Id = @Id";

            return await connection.ExecuteAsync(query, model) == 1;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"DELETE FROM dbo.{nameof(ProgressiveTax)}
                                WHERE Id = @id";

            return await connection.ExecuteAsync(query, id) == 1;
        }
    }
}
