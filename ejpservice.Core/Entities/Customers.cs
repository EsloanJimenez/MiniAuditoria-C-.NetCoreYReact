using ejpservice.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Entities
{
    public class Customers : BasePerson
    {
        [Key] 
        public int CustomerId { get; set; }
        public string? CompanyName { get; set; }
        public string? TradeName { get; set; }
        public string? Email {  get; set; }
        public string? Rnc {  get; set; }
    }
}
