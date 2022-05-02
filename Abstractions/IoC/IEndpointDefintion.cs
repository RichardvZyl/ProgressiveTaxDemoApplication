using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Abstractions.IoC;

public interface IEndpointDefintion
{
    public void DefineEndpoints(WebApplication app);

    // this would have worked fine if I wanted to define the service methods within the define endpoints class but I wanted to create a seperation
    // then I require DI to already have my services defined so I opted to use Scrutor
    //public void DefineServices(IServiceCollection services);

}
