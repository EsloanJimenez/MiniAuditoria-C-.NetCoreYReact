using ejpservice.Domain.Entities;
using ejpservice.Domain.Models;

namespace ejpservice.Domain.Interface
{
    public interface IPaymentWaiterRepository : IBaseRepository<PaymentWaiter>
    {
        List<TmPwSModel> GetPaymentWaiter();
    }
}
