using eWallet.BLL.DTO.Currency;
using eWallet.BLL.DTO.PersonalAccountDTO;
using eWallet.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace eWallet.BLL.Business_Model.Account_Actions
{
    public class Exchange : IOperation
    {
        private ClientDTO client;
        private CurrencyDTO inputC;
        private CurrencyDTO outputC;
        private double inputV;

        public Exchange(ClientDTO client, CurrencyDTO inputC, CurrencyDTO outputC, double inputV)
        {
            this.client = client;
            this.inputC = inputC;
            this.inputV = inputV;
            this.outputC = outputC;
        }
        public IEnumerable<AccountDTO> Execute()
        {
            var crate = GetCurrencyRate();

            var first = crate.Where(x => x.Key == inputC).FirstOrDefault();
            var second = crate.Where(x => x.Key == outputC).FirstOrDefault();

            client.Money.Where(acc => acc.ClientId == client.Id && acc.Name == first.Key).FirstOrDefault().Value -= inputV;
            client.Money.Where(acc => acc.ClientId == client.Id && acc.Name == second.Key).FirstOrDefault().Value += inputV / first.Value * second.Value;

            return client.Money;
        }

        private Dictionary<CurrencyDTO, double> GetCurrencyRate()
        {
            Dictionary<CurrencyDTO, double> rate = new Dictionary<CurrencyDTO, double>();

            XDocument document = XDocument.Load("ExchangeRate.xml");

            var items = from x in document.Element("rates").Elements("rate")
                        select new
                        {
                            key = (CurrencyDTO)Enum.Parse(typeof(CurrencyDTO), x.Element("key").Value, true),
                            value = double.Parse(x.Element("value").Value)
                        };

            foreach (var item in items)
                rate.Add(item.key, item.value);

            return rate;
        }
    }
}
