using System.Data;
using Abstractions.AspNetCore;
using Abstractions.Generics;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.DAL;

public interface ITaxCalculationTypeRepository : IGenericRepository<TaxCalculationType, int> { }

public sealed class TaxCalculationTypeRepository : ITaxCalculationTypeRepository
{
    private readonly string _connectionString;

    public TaxCalculationTypeRepository(IServiceCollection services)
        => _connectionString = ServiceExtensions.GetConnectionString(services, nameof(ProgressiveTaxDatabaase));

    public async Task<int> CreateAsync(TaxCalculationType model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var sqlCommand = @$"INSERT INTO dbo.{nameof(TaxCalculationType)}
                                   (PostalCode, TaxType, LastUpdated) 
                                   VALUES(@PostalCode, @TaxType, @LastUpdated)";

            _ = await connection.ExecuteAsync(sqlCommand, model);

            return model.Id;
        }
    }

    public async Task<TaxCalculationType?> GetByIdAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, PostalCode, TaxType, LastUpdated
                                FROM dbo.{nameof(TaxCalculationType)}
                                WHERE Id = @id";

            return (await connection.QueryAsync<TaxCalculationType>(query, id)).FirstOrDefault();
        }
    }

    public async Task<IEnumerable<TaxCalculationType>> ListAsync()
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"SELECT Id, PostalCode, TaxType, LastUpdated
                                FROM dbo.{nameof(TaxCalculationType)}";

            return await connection.QueryAsync<TaxCalculationType>(query) ?? new List<TaxCalculationType>();
        }
    }

    public async Task<bool> UpdateAsync(TaxCalculationType model)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"UPDATE dbo.{nameof(TaxCalculationType)}
                                PostalCode = @PostalCode, TaxType = TaxType, LastUpdated = @LastUpdated
                                WHERE Id = @Id";

            return await connection.ExecuteAsync(query, model) == 1;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var query = @$"DELETE FROM dbo.{nameof(TaxCalculationType)}
                                WHERE Id = @id";

            return await connection.ExecuteAsync(query, id) == 1;
        }
    }
}
