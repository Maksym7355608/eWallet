using eWallet.DAL.Entities.Currency;
using eWallet.DAL.Entities.PersonalAccount;
using System.Collections.Generic;
using System.Data.Entity;

namespace eWallet.DAL.EF
{
    public class Initializer : DropCreateDatabaseIfModelChanges<WalletContext>
    {
        protected override void Seed(WalletContext context)
        {
            context.Clients.Add(new Client
                {
                    Name = "Maksym",
                    Surname = "Chorny",
                    Email = "mmajor143@gmail.com",
                    Password = "naks882naks",
                    Money = new List<Account>()
                    { 
                        new Account()
                        { 
                            Name = Currency.Dollar, 
                            Value = 100
                        }
                    }
                });

            context.Clients.Add(new Client
            { 
                Name = "Kostya",
                Surname = "Salabay",
                Email = "extrimdysik@gmail.com",
                Password = "qwerty13",
                Money = new List<Account>
                {
                    new Account 
                    {
                        Name = Currency.Grivna,
                        Value = 10000
                    },
                    new Account
                    {
                        Name = Currency.Euro,
                        Value = 50
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
