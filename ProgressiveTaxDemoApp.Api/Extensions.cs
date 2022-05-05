using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApp.EndPoints.Extensions;

namespace ProgressiveTaxDemoApp.Api;

public static class Extensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IServiceCollection, ServiceCollection>();
        services.AddSingleton<IMappingAction<User, UserModel>, AddTaxToUserModel>();
    }

    public static MapperConfiguration MapperSetup
        => new(mapper =>
        {
            mapper.AddProfile(new ProgressiveTaxMapping());
            mapper.AddProfile(new TaxCalculationTypeMapping());
            mapper.AddProfile(new UserMapping());
        });

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
