using eWallet.BLL.DTO.PersonalAccountDTO;

namespace eWallet.BLL.DTO.Operations
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public AccountActionDTO Action { get; set; }
    }
}
