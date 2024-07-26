using ejpservice.Domain.Interface;
using ejpservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ejpservice.IOC.Dependencies
{
    public static class InventoryDependency
    {
        public static void AddInventoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();
        }
    }
}
