namespace ejpservice.Domain.Core
{
    public class BasePerson : BaseFollow
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone {  get; set; }
    }
}
