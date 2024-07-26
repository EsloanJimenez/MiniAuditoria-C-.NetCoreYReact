using ejpservice.Domain.Interface;
using ejpservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ejpservice.IOC.Dependencies
{
    public static class SalesDependency
    {
        public static void AddSalesDependency(this IServiceCollection service)
        {
            service.AddScoped<ISalesRepository, SalesRepository>();
        }
    }
}
