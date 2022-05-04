using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProgressiveTaxDemoApp.Endpoints;
public class SwaggerEndpointDefinition : IEndpointDefintion
{
    public void DefineEndpoints(WebApplication app)
    {
        var appName = Assembly.GetEntryAssembly()?.GetName().Name;

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{appName}"));
    }

    public void DefineServices(IServiceCollection services)
    {
        var appName = Assembly.GetEntryAssembly()?.GetName().Name;

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{appName}" });
        });
    }
}
