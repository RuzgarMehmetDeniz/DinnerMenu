using DinnerMenuPostgreSQL.Dtos.ChartDtos;

namespace DinnerMenuPostgreSQL.Service.ChartServices
{
    public interface IChartService
    {
        Task<List<ReservationChartDto>> GetLast7DaysReservationCountAsync();
        Task<List<CategoryProductCountChartDto>> GetCategoryProductCountAsync();
        Task<List<CategoryAvgPriceChartDto>> GetCategoryAvgPriceAsync();
    }
}
