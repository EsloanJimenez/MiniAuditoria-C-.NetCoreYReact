using ejpservice.Domain.Core.Models;

namespace ejpservice.Domain.Models
{
    public class SalesModel : BaseAmountModel
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string? Comment { get; set; }
    }
}
