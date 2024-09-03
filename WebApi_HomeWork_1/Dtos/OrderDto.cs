using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? OrderDate { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
