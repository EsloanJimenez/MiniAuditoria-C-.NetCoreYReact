using ejpservice.Domain.Entities;
using ejpservice.Domain.Models;

namespace ejpservice.Domain.Interface
{
    public interface ISalesRepository : IBaseRepository<Sales>
    {
        List<SalesModel> GetSales();
    }
}
