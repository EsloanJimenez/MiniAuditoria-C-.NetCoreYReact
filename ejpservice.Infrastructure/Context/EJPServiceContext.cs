using ejpservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ejpservice.Infrastructure.Context
{
    public class EJPServiceContext : DbContext
    {
        public EJPServiceContext(DbContextOptions<EJPServiceContext> dbContext) : base(dbContext) { }

        #region "Entities"
        /*public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }*/
        public DbSet<Customers> Customers { get; set; }
        /*
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<PaymentWaiter> PaymentWaiter { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        */
        #endregion
    }
}
