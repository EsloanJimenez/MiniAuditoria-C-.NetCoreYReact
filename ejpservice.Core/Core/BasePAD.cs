namespace ejpservice.Domain.Core
{
    public class BasePAD : BaseDateTime
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
