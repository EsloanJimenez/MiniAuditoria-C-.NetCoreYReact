using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Core.Models
{
    public class BaseDTModel
    {
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(100, ErrorMessage = "La descripcion no puede ser mayor a 100 caracteres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "La hora es requerida")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Price { get; set; }
    }
}
