using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ejpservice.UnitTests.Models
{
    public class CustomerRepositoryUnitTests
    {
        private EJPServiceContext _context = null;
        private ICustomersRepository _customerRepository;
        public CustomerRepositoryUnitTests()
        {
            var option = new DbContextOptionsBuilder<EJPServiceContext>()
                .UseInMemoryDatabase("EjpService")
                .Options;

            _context = new EJPServiceContext(option);
            _customerRepository = new CustomerRepository(_context);
        }
        [Fact]
        public void GetCustomers_WithValidCustomerModel()
        {
            //Arrange
            var customers = this._customerRepository.GetCustomers();

            //Expect

            //Assert
            Assert.NotNull(customers);
            Assert.IsType<List<CustomerModel>>(customers);
        }
    }
}
