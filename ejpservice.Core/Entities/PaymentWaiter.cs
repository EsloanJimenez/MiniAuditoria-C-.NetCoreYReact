using ejpservice.Domain.Core;
using ejpservice.Domain.Enum;

namespace ejpservice.Domain.Entities
{
    public class PaymentWaiter : BaseDateTime
    {
        public int PaymentId { get; set; }
        public int SalesId { get; set; }
        public int MemberId { get; set; }
        public int Payment {  get; set; }
        public Status Status { get; set; }
    }
}
