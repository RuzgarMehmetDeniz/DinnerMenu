using DinnerMenuPostgreSQL.Dtos.OrderItemDtos;

namespace DinnerMenuPostgreSQL.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public List<ResultOrderItemDto> OrderItems { get; set; } = new List<ResultOrderItemDto>();
    }
}
