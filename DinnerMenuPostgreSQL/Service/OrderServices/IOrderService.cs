using DinnerMenuPostgreSQL.Dtos.OrderDtos;

namespace DinnerMenuPostgreSQL.Service.OrderServices
{
    public interface IOrderService
    {
        Task<PagedResultDto<ResultOrderDto>> GetAllOrdersAsync(int pageNumber = 1, int pageSize = 10, int? year = null, int? month = null); Task<GetOrderByIdDto> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(int id);
        Task ChangeOrderStatusToPreparing(int id);
        Task ChangeOrderStatusToServed(int id);
        Task ChangeOrderStatusToCancel(int id);
        Task<List<ProductSelectDto>> GetProductsForSelectAsync();

    }
}
