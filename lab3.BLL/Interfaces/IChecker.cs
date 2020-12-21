using lab3.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.BLL.Interfaces
{
    public interface IChecker
    {
        void Check(OrderDTO order);
        void Check(ProductDTO product);
    }
}
