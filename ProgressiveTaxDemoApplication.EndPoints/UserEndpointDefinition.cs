using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.DAL;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Framework;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Endpoints;

public class UserEndpointDefinition : IEndpointDefintion
{
    private static string ControllerEndpoint => nameof(User);

    private readonly IUserService _service;

    public UserEndpointDefinition(IUserService service) => _service = service;

    public void DefineEndpoints(WebApplication app)
    {
        // Please note method groups no longer allocate more memory since C# 11 (current)
        _ = app.MapPost($"{ControllerEndpoint}/{{user:UserModel}}", _service.CreateAsync)
                .AddFilter<ValidationFilter<UserModel>>()
                .AllowAnonymous();

        _ = app.MapGet(ControllerEndpoint, _service.ListAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapGet($"{ControllerEndpoint}/{{email:string}}", _service.GetByEmailAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapPut($"{ControllerEndpoint}/{{user:UserModel}}", _service.UpdateAsync)
                .AddFilter<ValidationFilter<UserModel>>();

        _ = app.MapDelete($"{ControllerEndpoint}/{{id:Guid}}", _service.DeleteAsync)
                .AddFilter<ValidationFilter<UserModel>>();
    }

    // this would have worked fine if I wanted to define the service methods within this class but I wanted to create a seperation
    // then I require DI to already have my services defined so I opted to use Scrutor
    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ITaxCalculationService, TaxCalculationService>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserService, UserService>();
    }
}
