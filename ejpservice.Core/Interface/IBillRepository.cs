using ejpservice.Domain.Entities;
using ejpservice.Domain.Models;

namespace ejpservice.Domain.Interface
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        List<BillModel> GetBill();
    }
}
