using ejpservice.Domain.Core;

namespace ejpservice.Domain.Entities
{
    public class Sales : BasePAD
    {
        public int SalesId { get; set; }
        public int CustomerId { get; set; }
        public string? Comment { get; set; }
    }
}
