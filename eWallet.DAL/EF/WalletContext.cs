using eWallet.DAL.Entities.Currency;
using eWallet.DAL.Entities.PersonalAccount;
using System.Data.Entity;

namespace eWallet.DAL.EF
{
    public class WalletContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }


        static WalletContext() => Database.SetInitializer(new Initializer());
        public WalletContext()
        {

        }
        public WalletContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Account>();
        }
    }
}
