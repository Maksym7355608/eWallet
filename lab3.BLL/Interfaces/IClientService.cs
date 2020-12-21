using lab3.BLL.DTO;
using System.Collections.Generic;

namespace lab3.BLL.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ProductDTO> GetProductList();
        void Buy(OrderDTO order);
    }
}
