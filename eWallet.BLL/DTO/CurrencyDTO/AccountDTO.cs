using eWallet.BLL.DTO.PersonalAccountDTO;

namespace eWallet.BLL.DTO.Currency
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public CurrencyDTO Name { get; set; }
        public double Value { get; set; }

        public int ClientId { get; set; }
    }
}
