using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetWebAPI.IoC
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServicesDependecy(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            return services;
        }
    }
}
