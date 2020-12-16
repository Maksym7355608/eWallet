using eWallet.DAL.Entities.Currency;
using eWallet.DAL.Entities.Operations;
using eWallet.DAL.Entities.PersonalAccount;
using System;

namespace eWallet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }  // work with clients database
        IRepository<Transaction> Transactions { get; } // work with operations in clients accounts
        IRepository<Account> Accounts { get; } // work with client accounts
        void Save();
    }
}
