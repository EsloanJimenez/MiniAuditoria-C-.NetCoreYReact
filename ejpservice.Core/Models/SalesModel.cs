using ejpservice.Domain.Core;

namespace ejpservice.Domain.Models
{
    public class SalesModel : BaseAmountModel
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? Comment { get; set; }
    }
}
