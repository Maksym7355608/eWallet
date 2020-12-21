using lab3.DAL.Entities;

namespace lab3.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Count { get => Count; set => Count = value >= 0 ? value : 0; }
    }
}
