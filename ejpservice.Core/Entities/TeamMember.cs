using ejpservice.Domain.Core;
using ejpservice.Domain.Enum;

namespace ejpservice.Domain.Entities
{
    public class TeamMember : BasePerson
    {
        public int MemberId { get; set; }
        public string? Photo {  get; set; }
        public string? CardId { get; set; }
        public Sex Sex { get; set; }
        public Cluster Cluster { get; set; }
        public BankName BankName { get; set; }
        public BankType BankType { get; set; }
        public string? BankAccountNumber { get; set; }
        public Position Position { get; set; }
        public bool Status { get; set; }
    }
}
