namespace ejpservice.Domain.Core
{
    public class BaseDateTime : BaseFollow
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
