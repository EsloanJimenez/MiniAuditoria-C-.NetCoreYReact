using ejpservice.Domain.Entities;
using ejpservice.Domain.Models;

namespace ejpservice.Domain.Interface
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        List<InventoryModel> GetInventory();
        SalesTotalModel GetSalesTotal();
    }
}
