using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ejpservice.UnitTests.Models
{
    public class InventoryRepositoryUnitTests
    {
        private EJPServiceContext _context;
        private IInventoryRepository _inventoryRepository;
        public InventoryRepositoryUnitTests()
        {
            var op = new DbContextOptionsBuilder<EJPServiceContext>()
                .UseInMemoryDatabase("EjpInventory")
                .Options;

            _context = new EJPServiceContext(op);
            _inventoryRepository = new InventoryRepository(_context);
        }
        [Fact]
        public void GetInventory_WithValidInventoryModel()
        {
            //Arrange
            var inventory = this._inventoryRepository.GetInventory();

            //Assert
            Assert.NotNull(inventory);
            Assert.IsType<List<InventoryModel>>(inventory);
        }
    }
}
