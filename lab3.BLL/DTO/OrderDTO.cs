using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ProductIds { get; set; }
        public ProductDTO Product { get; set; }
        public int OrderCount { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public bool? IsSuccess { get; set; }
    }
}
