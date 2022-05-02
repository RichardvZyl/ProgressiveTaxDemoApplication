using Abstractions.Generics;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApplication.DAL;

public interface ITaxCalculationTypeRepository : IGenericRepository<TaxCalculationType, int> { }

public sealed class TaxCalculationTypeRepository : ITaxCalculationTypeRepository
{
    public TaxCalculationTypeRepository()
    {

    }

    public async Task<int> CreateAsync(TaxCalculationType model)
        => throw new NotImplementedException();

    public async Task<TaxCalculationType> GetByIdAsync(int id)
        => throw new NotImplementedException();

    public async Task<IEnumerable<TaxCalculationType>> ListAsync()
        => throw new NotImplementedException();

    public async Task<bool> UpdateAsync(TaxCalculationType model)
        => throw new NotImplementedException();

    public async Task<bool> DeleteAsync(int id)
        => throw new NotImplementedException();

    public async Task<IDictionary<int, TaxCalculationType>> GetTableAsync()
        => throw new NotImplementedException();

}
