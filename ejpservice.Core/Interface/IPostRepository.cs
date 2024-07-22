using ejpservice.Domain.Entities;

namespace ejpservice.Domain.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Customers>> GetCustomers();
    }
}
