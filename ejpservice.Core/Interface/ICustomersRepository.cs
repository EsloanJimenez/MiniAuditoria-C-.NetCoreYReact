using ejpservice.Domain.Models;
using ejpservice.Domain.Entities;

namespace ejpservice.Domain.Interface
{
    public interface ICustomersRepository : IBaseRepository<Customers>
    {
        List<CustomerModel> GetCustomers();
    }
}
