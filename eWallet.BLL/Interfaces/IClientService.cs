using eWallet.BLL.DTO.Currency;
using eWallet.BLL.DTO.PersonalAccountDTO;
using System.Collections.Generic;

namespace eWallet.BLL.Interfaces
{
    public interface IClientService : IAccountService
    {
        void CreateClient(ClientDTO client);
        ClientDTO GetClient(int id);
        AccountDTO GetClientAccount(int id);
        new void Dispose();
        int? ValidateClient(string email, string password);
        IEnumerable<AccountDTO> GetAccounts(int id);
    }
}
