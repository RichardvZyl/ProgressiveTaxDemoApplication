using Abstractions.Generics;
using Abstractions.Results;
using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApp.DAL;

namespace ProgressiveTaxDemoApp.Framework;

public interface ITaxCalculationTypeService : IGenericService<TaxCalculationType, TaxCalculationTypeModel, int> { }

public class TaxCalculationTypeService : ITaxCalculationTypeService
{
    private readonly ITaxCalculationTypeRepository _repository;
    private readonly IMapper _autoMapper;

    public TaxCalculationTypeService
    (
        ITaxCalculationTypeRepository repository,
        IMapper autoMapper
    )
    {
        _repository = repository;
        _autoMapper = autoMapper;
    }

    public async Task<IResult<int>> CreateAsync(TaxCalculationTypeModel model) // did not have time to implement factory pattern (yet)
        => await Result<int>.SuccessAsync(await _repository.CreateAsync(new (model.PostalCode, model.TaxType)));

    public async Task<IResult<TaxCalculationTypeModel>> GetAsync(int id) 
        => await Result<TaxCalculationTypeModel>.SuccessAsync(_autoMapper.Map<TaxCalculationTypeModel>(await _repository.GetByIdAsync(id)));
    
    public async Task<IResult<IEnumerable<TaxCalculationTypeModel>>> ListAsync()
        => await Result<IEnumerable<TaxCalculationTypeModel>>.SuccessAsync(_autoMapper.Map<IEnumerable<TaxCalculationTypeModel>>(await _repository.ListAsync()));

    public async Task<IResult> UpdateAsync(TaxCalculationTypeModel model)
    {
        var taxCalculationType = await _repository.GetByIdAsync(model.Id);

        if (taxCalculationType is null)
            return await Result.FailAsync($"Could not find {nameof(TaxCalculationType)} with ID {model.Id}", 204);

        taxCalculationType.Update(model.PostalCode, model.TaxType);

        return await _repository.UpdateAsync(taxCalculationType)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();
    }

    public async Task<IResult> DeleteAsync(int id)
        => await _repository.DeleteAsync(id)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();

}
