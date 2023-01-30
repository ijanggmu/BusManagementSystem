using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bus.Services
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
