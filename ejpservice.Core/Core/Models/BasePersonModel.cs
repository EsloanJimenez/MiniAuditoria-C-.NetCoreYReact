using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Core.Models
{
    public class BasePersonModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        public string? FirstName { get; set; }
        [StringLength(50, ErrorMessage = "El apellido no puede ser mayor a 50 caracteres")]
        public string? LastName { get; set; }
    }
}
