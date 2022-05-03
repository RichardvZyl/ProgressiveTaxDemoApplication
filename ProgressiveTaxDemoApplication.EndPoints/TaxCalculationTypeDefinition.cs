using Abstractions.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Framework;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Endpoints;

public class TaxCalculationTypeDefintion : IEndpointDefintion
{
    private static string ControllerEndpoint => nameof(TaxCalculationType);

    private readonly ITaxCalculationTypeService _service;

    public TaxCalculationTypeDefintion(ITaxCalculationTypeService service) => _service = service;

    public void DefineEndpoints(WebApplication app)
    {
        // Please note method groups no longer allocate more memory since C# 11 (current) 
        _ = app.MapPost($"{ControllerEndpoint}/{{taxCalculationType:TaxCalculationTypeModel}}", _service.CreateAsync)
                .AddFilter<ValidationFilter<TaxCalculationTypeModel>>();

        _ = app.MapGet(ControllerEndpoint, _service.ListAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapGet($"{ControllerEndpoint}/{{id:int}}", _service.GetAsync)
                .AddFilter<ResultFilter>();

        _ = app.MapPut($"{ControllerEndpoint}/{{taxCalculationType:TaxCalculationTypeModel}}", _service.UpdateAsync)
                .AddFilter<ValidationFilter<TaxCalculationTypeModel>>();

        _ = app.MapDelete($"{ControllerEndpoint}/{{id:int}}", _service.DeleteAsync)
                .AddFilter<ResultFilter>();
        ;
    }

    // this would have worked fine if I wanted to define the service methods within this class but I wanted to create a seperation
    // then I require DI to already have my services defined so I opted to use Scrutor
    public void DefineServices(IServiceCollection services) { }
}
