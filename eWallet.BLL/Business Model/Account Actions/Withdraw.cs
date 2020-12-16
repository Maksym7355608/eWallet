using eWallet.BLL.DTO.Currency;
using eWallet.BLL.DTO.PersonalAccountDTO;
using eWallet.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace eWallet.BLL.Business_Model.Account_Actions
{
    public class Withdraw : IOperation
    {
        private ClientDTO client;
        private CurrencyDTO currency;
        private double value;

        public Withdraw(ClientDTO client, CurrencyDTO currency, double value)
        {
            this.client = client;
            this.currency = currency;
            this.value = value;
        }

        public IEnumerable<AccountDTO> Execute()
        {
            client.Money.Where(c => c.Name == currency).FirstOrDefault().Value -= value;
            return client.Money;
        }
    }
}
