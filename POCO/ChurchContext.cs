using System.Data.Entity;

namespace POCO
{
    public class ChurchContext : DbContext
    {
        public ChurchContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Church> Churches { get; set; }
        public DbSet<ContributorGroup> ContributorGroups { get; set; }
        public DbSet<ContributorKey> ContributorKeys { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Donation>().Property(c => c.TransactionDate).HasDefaultValueSql("getdate()");
        }
    }


}
