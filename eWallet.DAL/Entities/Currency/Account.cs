using eWallet.DAL.Entities.PersonalAccount;

namespace eWallet.DAL.Entities.Currency
{
    public class Account
    {
        public int Id { get; set; }
        public Currency Name { get; set; }
        public double Value { get; set; }

        public int ClientId { get; set; }
    }
}
