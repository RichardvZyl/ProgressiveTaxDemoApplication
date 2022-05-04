using Abstractions.EntityFrameworkCore;
using Abstractions.IoC;
using ProgressiveTaxDemoApp.Api;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Endpoints;
using ProgressiveTaxDemoApp.EndPoints.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddContextUseInMemory<ProgressiveTaxDatabase>();

builder.Services.AddServices();

//builder.Services.AddSecurity();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddEndpointDefintions(typeof(SwaggerEndpointDefinition));

builder.Services.AddSingleton<ITaxCalculationService, TaxCalculationService>();

var app = builder.Build();

app.UseEndpointDefintions();

app.AddRequestPipeline();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.Run();
