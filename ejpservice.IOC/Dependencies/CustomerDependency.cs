using ejpservice.Domain.Interface;
using ejpservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ejpservice.IOC.Dependencies
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependency(this IServiceCollection services)
        {
            services.AddScoped<ICustomersRepository, CustomerRepository>();
        }
    }
}
