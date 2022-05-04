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

public class UserEndpointDefinition : IEndpointDefintion
{
    private static string ControllerEndpoint => nameof(User);

    public void DefineEndpoints(WebApplication app)
    {
        // Please note method groups no longer allocate more memory since C# 11 (current)
        _ = app.MapPost($"{ControllerEndpoint}/{{user:UserModel}}", CreateAsync)
                .AddFilter<ValidationFilter<UserModel>>()
                .AllowAnonymous();

        _ = app.MapGet(ControllerEndpoint, ListAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapGet($"{ControllerEndpoint}/{{email:string}}", GetByEmailAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapPut($"{ControllerEndpoint}/{{user:UserModel}}", UpdateAsync)
                .AddFilter<ValidationFilter<UserModel>>();

        _ = app.MapDelete($"{ControllerEndpoint}/{{id:Guid}}", DeleteAsync)
                .AddFilter<ValidationFilter<UserModel>>();
    }

    public void DefineServices(IServiceCollection services)
        => services.AddSingleton<IUserRepository, UserRepository>();


    internal async Task<IResult<Guid>> CreateAsync(IUserRepository _repository, UserModel model) // did not have time to implement factory pattern (yet)
        => await Result<Guid>.SuccessAsync(
            await _repository.CreateAsync(
                new(model.Email, model.PostalCode, model.BrutoSalary)));

    internal static async Task<IResult<UserModel>> GetAsync(IUserRepository _repository, IMapper _autoMapper, Guid id)
         => await Result<UserModel>.SuccessAsync(
             _autoMapper.Map<UserModel>(
                 await _repository.GetByIdAsync(id)));

    internal static async Task<IResult<IEnumerable<UserModel>>> ListAsync(IUserRepository _repository, IMapper _autoMapper)
        => await Result<IEnumerable<UserModel>>.SuccessAsync(
            _autoMapper.Map<IEnumerable<UserModel>>(
                await _repository.ListAsync()));

    internal static async Task<IResult> UpdateAsync(IUserRepository _repository, IMapper _autoMapper, UserModel model)
    {
        var user = await _repository.GetByIdAsync(model.Id);

        if (user is null)
            return await Result<IEnumerable<TaxCalculationType>>.FailAsync($"Could not find {nameof(User)} with ID {model.Id}", 204);

        user.Update(model.PostalCode, model.BrutoSalary);

        return await _repository.UpdateAsync(user)
            ? await Result<IEnumerable<TaxCalculationType>>.SuccessAsync()
            : await Result<IEnumerable<TaxCalculationType>>.FailAsync();
    }

    internal static async Task<IResult> DeleteAsync(IUserRepository _repository, Guid id)
        => await _repository.DeleteAsync(id)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();

    internal static Task<IResult<UserModel>> GetByEmailAsync(IUserRepository _repository, IMapper _autoMapper, string email)
        => Result<UserModel>.SuccessAsync(
            _autoMapper.Map<UserModel>(
                _repository.GetByEmail(email)));
}
