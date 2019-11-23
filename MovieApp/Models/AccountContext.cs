using MovieApp.Ioc;
using System.Data.Entity;

namespace MovieApp.Models
{
    public class AccountContext : EntityRepository<Account>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
        }
    }
}