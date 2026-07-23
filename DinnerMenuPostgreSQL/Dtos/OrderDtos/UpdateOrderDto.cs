namespace DinnerMenuPostgreSQL.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
    }
}
