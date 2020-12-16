using eWallet.DAL.Entities.PersonalAccount;

namespace eWallet.DAL.Entities.Operations
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public AccountAction Action { get; set; }
    }
}
