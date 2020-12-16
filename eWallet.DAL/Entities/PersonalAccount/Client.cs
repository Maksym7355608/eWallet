using eWallet.DAL.Entities.Currency;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eWallet.DAL.Entities.PersonalAccount
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public ICollection<Account> Money { get; set; }
    }
}
