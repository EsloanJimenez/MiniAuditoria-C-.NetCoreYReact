using ejpservice.Domain.Core.Models;
using ejpservice.Domain.Enum;

namespace ejpservice.Domain.Models
{
    public class TmPwSModel : BaseDTModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Payment {  get; set; }
        public Status Status { get; set; }
    }
}
