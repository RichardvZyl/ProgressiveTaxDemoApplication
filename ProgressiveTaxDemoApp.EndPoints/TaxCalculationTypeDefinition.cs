using Abstractions.IoC;
using Abstractions.Results;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.DAL;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using IResult = Abstractions.Results.IResult;

namespace ProgressiveTaxDemoApp.Endpoints;

public class TaxCalculationTypeDefintion : IEndpointDefintion
{
    private static string ControllerEndpoint => nameof(TaxCalculationType);

    public void DefineEndpoints(WebApplication app)
    {
        // Please note method groups no longer allocate more memory since C# 11 (current) 
        _ = app.MapPost($"{ControllerEndpoint}/{{model}}", CreateAsync)
                .AddFilter<ValidationFilter<TaxCalculationTypeModel>>();

        _ = app.MapGet(ControllerEndpoint, ListAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapGet($"{ControllerEndpoint}/{{id}}", GetAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapPut($"{ControllerEndpoint}/{{model}}", UpdateAsync)
                .AddFilter<ValidationFilter<TaxCalculationTypeModel>>();

        _ = app.MapDelete($"{ControllerEndpoint}/{{id}}", DeleteAsync)
                .AddFilter<ResultFilter>();
    }

    public void DefineServices(IServiceCollection services)
        => services.AddSingleton<ITaxCalculationTypeRepository, TaxCalculationTypeRepository>();


    internal static async Task<IResult<int>> CreateAsync(IProgressiveTaxRepository _repository, ProgressiveTaxModel model) //did not have time to implment factory pattern (yet)
        => await Result<int>.SuccessAsync(
            await _repository.CreateAsync(
                new(model.Rate, model.From)));

    internal static async Task<IResult<ProgressiveTaxModel>> GetAsync(IProgressiveTaxRepository _repository, IMapper _autoMapper, int id)
        => await Result<ProgressiveTaxModel>.SuccessAsync(
            _autoMapper.Map<ProgressiveTaxModel>(
                await _repository.GetByIdAsync(id)));

    internal static async Task<IResult<IEnumerable<ProgressiveTaxModel>>> ListAsync(IProgressiveTaxRepository _repository, IMapper _autoMapper)
        => await Result<IEnumerable<ProgressiveTaxModel>>.SuccessAsync(
            _autoMapper.Map<IEnumerable<ProgressiveTaxModel>>(
                await _repository.ListAsync()));

    internal static async Task<IResult> UpdateAsync(IProgressiveTaxRepository _repository, ProgressiveTaxModel model)
    {
        var progressiveTax = await _repository.GetByIdAsync(model.Id);

        if (progressiveTax is null)
            return await Result.FailAsync($"Could not find {nameof(ProgressiveTax)} with ID {model.Id}", 204);

        progressiveTax.Update(model.Rate, model.From);

        return await _repository.UpdateAsync(progressiveTax)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();
    }

    internal static async Task<IResult> DeleteAsync(ITaxCalculationTypeRepository _repository, int id)
        => await _repository.DeleteAsync(id)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();
}
