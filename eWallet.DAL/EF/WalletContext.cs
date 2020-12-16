using eWallet.DAL.Entities.Currency;
using eWallet.DAL.Entities.Operations;
using eWallet.DAL.Entities.PersonalAccount;
using System.Data.Entity;

namespace eWallet.DAL.EF
{
    public class WalletContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        static WalletContext() => Database.SetInitializer(new Initializer());

        public WalletContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Account>().
                HasRequired(c => c.Client).
                WithMany(a => a.Money).
                HasForeignKey(ci => ci.ClientId);

            builder.Entity<Transaction>().
                HasKey(c => c.Client);
        }
    }
}
