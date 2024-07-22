using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using System.Linq.Expressions;

namespace ejpservice.Infrastructure.Repositories.Moq
{
    internal class CustomerMoqRep : ICustomersRepository
    {
        private List<Customers> customers;
        public CustomerMoqRep()
        {
            this.customers = new List<Customers>();
        }
        public Task<bool> Exists(Expression<Func<Customers, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Customers> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customers>> GetAll(Expression<Func<Customers, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Customers entity)
        {
            throw new NotImplementedException();
        }

        public Task Save(Customers entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
