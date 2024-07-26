using ejpservice.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Entities
{
    public class Sales : BasePAD
    {
        [Key]
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string? Comment { get; set; }
    }
}
