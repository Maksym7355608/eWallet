using eWallet.BLL.DTO.Currency;
using System.Collections.Generic;

namespace eWallet.BLL.Interfaces
{
    public interface IOperation
    {
        IEnumerable<AccountDTO> Execute();
    }
}
