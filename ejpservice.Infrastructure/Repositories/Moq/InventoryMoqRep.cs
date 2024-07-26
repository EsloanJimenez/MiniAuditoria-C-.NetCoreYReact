using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using System.Linq.Expressions;

namespace ejpservice.Infrastructure.Repositories.Moq
{
    public class InventoryMoqRep : IInventoryRepository
    {
        private readonly List<Inventory> inventories;
        public InventoryMoqRep()
        {
            inventories = new List<Inventory>();
        }

        public Task<bool> Exists(Expression<Func<Inventory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inventory>> GetAll(Expression<Func<Inventory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<InventoryModel> GetInventory()
        {
            throw new NotImplementedException();
        }

        public SalesTotalModel GetSalesTotal()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task Save(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Inventory entity)
        {
            throw new NotImplementedException();
        }
    }
}
