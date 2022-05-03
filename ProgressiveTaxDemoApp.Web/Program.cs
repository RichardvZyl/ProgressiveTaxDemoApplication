using Abstractions.EntityFrameworkCore;
using Abstractions.IoC;
using ProgressiveTaxDemoApp.Database;
using ProgressiveTaxDemoApp.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddContextUseSql<ApplicationDbContext>();

//builder.AddIdentityFramework<ApplicationDbContext>();

builder.Services.AddRazorPages();

//builder.Services.AddSecurity();

builder.Services.AddServices();

builder.Services.AddEndpointDefintions();

builder.Services.AddSingleton(Extensions.MapperSetup.CreateMapper());


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
