namespace ejpservice.Api.Models.Create
{
    public class BaseAuditoryModel : BaseRemoveModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? UserCreation {  get; set; }
    }
}
