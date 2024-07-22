namespace ejpservice.Api.Models.Create
{
    public class CustomerAddModel : BaseAuditoryModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? TradeName { get; set; }
        public string? Email { get; set; }
        public string Phone {  get; set; }
        public string? Rnc { get; set; }
    }
}
