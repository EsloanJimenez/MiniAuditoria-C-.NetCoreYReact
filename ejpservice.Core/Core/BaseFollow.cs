namespace ejpservice.Domain.Core
{
    public abstract class BaseFollow
    {
        protected BaseFollow()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }
        public DateTime CreationDate {  get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserCreation {  get; set; }
        public int? UserMod {  get; set; }
        public int? UserDelete { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
