using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Abstractions.Extensions;
public static class Extensions
{
    public static void AddContextUseSql<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        _ = builder.Services.AddDbContext<T>(options =>
            options.UseSqlServer(connectionString));

        _ = builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    }

    public static void AddRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseMigrationsEndPoint();
        }
        else
        {
            _ = app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _ = app.UseHsts();
        }
    }

    public static void AddSwagger(WebApplication app)
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(c
            => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProgressiveTaxDemoApplication")
        );
    }

    public static void AddSwagger(IServiceCollection services)
    {

        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter into field the word 'Bearer' followed by a space and the the JWT token value",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });
        });
    }

}
