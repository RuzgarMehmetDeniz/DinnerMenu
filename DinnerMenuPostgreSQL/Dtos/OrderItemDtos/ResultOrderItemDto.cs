namespace DinnerMenuPostgreSQL.Dtos.OrderItemDtos
{
    public class ResultOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}
