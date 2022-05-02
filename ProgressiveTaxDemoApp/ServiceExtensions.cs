using AutoMapper;
using Abstractions.IoC;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Web.Mappings;
using ProgressiveTaxDemoApp.Framework;

namespace ProgressiveTaxDemoApp.Web;

public static class ServiceExtensions
{
    public static void AddServiceEndpoints(this IServiceCollection services)
    {
        services.AddEndpointDefintions(typeof(User));
        services.AddEndpointDefintions(typeof(ProgressiveTax));
        services.AddEndpointDefintions(typeof(TaxCalculationType));
    }

    public static MapperConfiguration MapperSetup 
        => new(mapper =>
        {
            mapper.AddProfile(new ProgressiveTaxMapping());
            mapper.AddProfile(new UserMapping());
            mapper.AddProfile(new TaxCalculationTypeMapping());
        });

    public static void AddServices(this IServiceCollection services)
    {
        services.AddClassesInterfaces(typeof(IUserService).Assembly);
        services.AddClassesInterfaces(typeof(ITaxCalculationTypeService).Assembly);
        services.AddClassesInterfaces(typeof(IProgressiveTaxService).Assembly);
        services.AddClassesInterfaces(typeof(ITaxCalculationService).Assembly);
        services.AddAutoMapper(typeof(Program).Assembly);
    }
}
