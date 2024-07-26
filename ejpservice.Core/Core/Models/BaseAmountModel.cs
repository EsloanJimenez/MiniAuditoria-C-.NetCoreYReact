using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Core.Models
{
    public class BaseAmountModel : BaseDTModel
    {
        [Required(ErrorMessage ="La cantidad es requerida")]
        public int Amount { get; set; }
        public decimal SubTotal { get; set; }
    }
}
