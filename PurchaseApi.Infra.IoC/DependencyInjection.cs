using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PurchaseApi.Application.Mappings;
using PurchaseApi.Application.Services;
using PurchaseApi.Application.Services.Interface;
using PurchaseApi.Domain.Authentication;
using PurchaseApi.Domain.Repositories;
using PurchaseApi.Infra.Data.Authentication;
using PurchaseApi.Infra.Data.Context;
using PurchaseApi.Infra.Data.Repositories;

namespace PurchaseApi.Infra.IoC;

public static class DependencyInjection
{
    //Here we are going to inject our dependencies, we do that here by separating the infra from the services ones.
    
    //Injecting infrastructure
    public static IServiceCollection AddInfrastructe(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
                            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    //Injecting services 
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapper)); //Just need to pass one here
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}