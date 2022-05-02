using Abstractions.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Framework;

namespace ProgressiveTaxDemoApplication.EndPoints;

public class ProgressiveTaxEndpointDefinition : IEndpointDefintion
{
    private static string ControllerEndpoint => nameof(ProgressiveTax);

    private readonly IProgressiveTaxService _service;

    public ProgressiveTaxEndpointDefinition(IProgressiveTaxService service) => _service = service;


    public void DefineEndpoints(WebApplication app)
    {
        // Please note method groups no longer allocate more memory since C# 11 (current) 
        _ = app.MapPost($"{ControllerEndpoint}/{{model:ProgressiveTaxModel}}", _service.CreateAsync)
                .AddFilter((ctx, next) => async (context) => await next(context));

        _ = app.MapGet(ControllerEndpoint, _service.ListAsync)
                .AddFilter((ctx, next) => async (context) => await next(context));

        _ = app.MapGet($"{ControllerEndpoint}/{{id:int}}", _service.GetAsync)
                .AddFilter((ctx, next) => async (context) => await next(context));

        _ = app.MapPut($"{ControllerEndpoint}/{{taxCalculationType:TaxCalculationType}}", _service.UpdateAsync)
                .AddFilter((ctx, next) => async (context) => await next(context));

        _ = app.MapDelete($"{ControllerEndpoint}/{{id:int}}", _service.DeleteAsync)
                .AddFilter((ctx, next) => async (context) => await next(context));
    }

    // this would have worked fine if I wanted to define the service methods within this class but I wanted to create a seperation
    // then I require DI to already have my services defined so I opted to use Scrutor
    //public void DefineServices(IServiceCollection services) => services.AddSingleton<IProgressiveTaxService, ProgressiveTaxService>();
}
