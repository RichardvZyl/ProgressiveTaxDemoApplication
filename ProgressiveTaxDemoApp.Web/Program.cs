using Abstractions.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Endpoints;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Web;
using ProgressiveTaxDemoApp.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.AddContextUseSql<ProgressiveTaxDatabaase>("defaultconnection");

//builder.AddIdentityFramework<ApplicationDbContext>();

builder.Services.AddRazorPages();

//builder.Services.AddSecurity();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddServices();

builder.Services.AddEndpointDefintions(typeof(User));

var app = builder.Build();

app.UseEndpointDefintions();

app.AddRequestPipeline();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();

app.Run();
