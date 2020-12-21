using lab3.BLL.DTO;
using System.Collections.Generic;

namespace lab3.BLL.Interfaces
{
    public interface IModeringService
    {
        IEnumerable<ProductDTO> GetProductList();
        void AddProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
    }
}
