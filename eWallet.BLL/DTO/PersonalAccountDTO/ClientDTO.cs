using eWallet.BLL.DTO.Currency;
using System.Collections.Generic;

namespace eWallet.BLL.DTO.PersonalAccountDTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdBalance { get; set; }
        public ICollection<AccountDTO> Money { get; set; }
    }
}
