namespace DinnerMenuPostgreSQL.Dtos.OrderDtos
{
    public class ProductSelectDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
