using ejpservice.Domain.Core;
using ejpservice.Domain.Enum;

namespace ejpservice.Domain.Models
{
    public class AdminModel : BasePhotoModel
    {
        public int AdminId { get; set; }
        public string? UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public AdminRole Role { get; set; }
    }
}