using ejpservice.Domain.Enum;

namespace ejpservice.Domain.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Photo {  get; set; }
        public DateTime CreationDate { get; set; }
        public AdminRole Role { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
