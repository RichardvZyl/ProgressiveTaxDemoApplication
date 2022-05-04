using AutoMapper;
//using Abstractions.IoC;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Endpoints;
using ProgressiveTaxDemoApp.Web.Mappings;

namespace ProgressiveTaxDemoApp.Web;

public static class Extensions
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
            mapper.AddProfile(new TaxCalculationTypeMapping());
            mapper.AddProfile(new UserMapping());
        });

    public static void AddServices(this IServiceCollection services)
    {
        //usually you would only need to define top level Interfaces and IoC Abstractions would take care of the rest but having issues with .net7.0 so I defined all interfaces
        //services.AddClassesInterfaces(typeof(ITaxCalculationTypeRepository).Assembly);
        //services.AddClassesInterfaces(typeof(ITaxCalculationTypeService).Assembly);
        //services.AddClassesInterfaces(typeof(IUserRepository).Assembly);
        //services.AddClassesInterfaces(typeof(IUserService).Assembly);
        //services.AddClassesInterfaces(typeof(IProgressiveTaxRepository).Assembly);
        //services.AddClassesInterfaces(typeof(IProgressiveTaxService).Assembly);
        //services.AddClassesInterfaces(typeof(ITaxCalculationService).Assembly);
        
    }

    public static void AddRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseMigrationsEndPoint();
            return;
        }

        _ = app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        _ = app.UseHsts();
    }
}
