using DinnerMenuPostgreSQL.Dtos.OrderItemDtos;

namespace DinnerMenuPostgreSQL.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
    }
}
