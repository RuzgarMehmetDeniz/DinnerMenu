using DinnerMenuPostgreSQL.Dtos.ReservationDtos;

namespace DinnerMenuPostgreSQL.Service.DashboardServices
{
    public interface IDashboardService
    {
        Task<int> GetTotalReservationCountAsync();
        Task<int> GetPendingReservationCountAsync();
        Task<int> GetApprovedReservationCountAsync();
        Task<int> GetCancelledReservationCountAsync();
        Task<int> GetTodayReservationCountAsync();
        Task<int> GetTotalCustomerCountAsync();
        Task<int> GetTotalMenuProductCountAsync();
        Task<int> GetTodayOrderCountAsync();
        Task<List<ResultReservationDto>> GetTodayReservationListAsync();
    }
}
