using Abstractions.Generics;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApplication.DAL;

public interface IProgressiveTaxRepository : IGenericRepository<ProgressiveTax, int> { }

public sealed class ProgressiveTaxRepository : IProgressiveTaxRepository
{
    public ProgressiveTaxRepository()
    {

    }

    public async Task<int> CreateAsync(ProgressiveTax model) 
        => throw new NotImplementedException();

    public async Task<ProgressiveTax> GetByIdAsync(int id) 
        => throw new NotImplementedException();

    public async Task<IEnumerable<ProgressiveTax>> ListAsync() 
        => throw new NotImplementedException();

    public async Task<bool> UpdateAsync(ProgressiveTax model) 
        => throw new NotImplementedException();
    
    public async Task<bool> DeleteAsync(int id) 
        => throw new NotImplementedException();

    public async Task<IDictionary<int, ProgressiveTax>> GetTableAsync()
        => throw new NotImplementedException();

}
