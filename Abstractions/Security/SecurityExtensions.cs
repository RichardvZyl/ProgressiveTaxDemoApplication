using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Abstractions.Security;

public static class SecurityExtensions
{
    public static void AddSecurity(this IServiceCollection services)
    {
        _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        _ = services.AddAuthorization(options
            => options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
    }
}
