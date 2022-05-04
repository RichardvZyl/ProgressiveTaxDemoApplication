using System.Reflection;
using Abstractions.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProgressiveTaxDemoApp.Endpoints;
public class SwaggerEndpointDefinition : IEndpointDefintion
{
    private string ApplicationName => Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty;

    public void DefineEndpoints(WebApplication app)
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{ApplicationName}"));
    }

    public void DefineServices(IServiceCollection services)
    {
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{ApplicationName}" });
        });
    }
}
