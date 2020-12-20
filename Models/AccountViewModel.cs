using eWallet.BLL.DTO.Currency;

namespace eWallet.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public CurrencyDTO Name { get; set; }
        public double Value { get; set; }

        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }
    }
}