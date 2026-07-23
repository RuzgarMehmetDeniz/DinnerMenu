namespace DinnerMenuPostgreSQL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
