using eWallet.BLL.DTO.Currency;
using System.Collections.Generic;

namespace eWallet.BLL.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(AccountDTO account);
        void DeleteAccount(AccountDTO account);
        void UpdateAccount(IEnumerable<AccountDTO> accounts);
        void Dispose();
    }
}
