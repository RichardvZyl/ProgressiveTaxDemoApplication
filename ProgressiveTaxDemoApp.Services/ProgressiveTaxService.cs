using Abstractions.Generics;
using Abstractions.Results;
using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApp.DAL;

namespace ProgressiveTaxDemoApp.Framework;

public interface IProgressiveTaxService : IGenericService<ProgressiveTax, ProgressiveTaxModel, int> { }

public class ProgressiveTaxService : IProgressiveTaxService
{
    private readonly IProgressiveTaxRepository _repository;
    private readonly ITaxCalculationService _updateService;
    private readonly IMapper _autoMapper;

    public ProgressiveTaxService
    (
        IProgressiveTaxRepository repository,
        ITaxCalculationService updateService,
        IMapper autoMapper
    )
    {
        _repository = repository;
        _updateService = updateService;
        _autoMapper = autoMapper;
    }

    public async Task<IResult<int>> CreateAsync(ProgressiveTaxModel model) //did not have time to implment factory pattern (yet)
        => await Result<int>.SuccessAsync(await _repository.CreateAsync(new(model.Rate, model.From)));

    public async Task<IResult<ProgressiveTaxModel>> GetAsync(int id)
        => await Result<ProgressiveTaxModel>.SuccessAsync(_autoMapper.Map<ProgressiveTaxModel>(await _repository.GetByIdAsync(id)));

    public async Task<IResult<IEnumerable<ProgressiveTaxModel>>> ListAsync()
        => await Result<IEnumerable<ProgressiveTaxModel>>.SuccessAsync(_autoMapper.Map<IEnumerable<ProgressiveTaxModel>>(await _repository.ListAsync()));

    public async Task<IResult> UpdateAsync(ProgressiveTaxModel model)
    {
        var progressiveTax = await _repository.GetByIdAsync(model.Id);

        if (progressiveTax is null)
            return await Result.FailAsync($"Could not find {nameof(ProgressiveTax)} with ID {model.Id}", 204);

        progressiveTax.Update(model.Rate, model.From);

        return await _repository.UpdateAsync(progressiveTax)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();
    }

    public async Task<IResult> DeleteAsync(int id)
        => await _repository.DeleteAsync(id)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();
}
