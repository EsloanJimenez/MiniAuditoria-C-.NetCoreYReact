using ejpservice.Domain.Core.Models;

namespace ejpservice.Domain.Models
{
    public class CustomerModel : BasePhoneModel
    {
        public int CustomerId { get; set; }
        public string? CompanyName { get; set; }
        public string? Email {  get; set; }
    }
}
