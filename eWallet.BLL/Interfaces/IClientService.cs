using eWallet.BLL.DTO.Currency;
using eWallet.BLL.DTO.PersonalAccountDTO;

namespace eWallet.BLL.Interfaces
{
    public interface IClientService : IAccountService
    {
        void CreateClient(ClientDTO client);
        ClientDTO GetClient(int id);
        AccountDTO GetClientAccount(CurrencyDTO currency);
        new void Dispose();
    }
}
