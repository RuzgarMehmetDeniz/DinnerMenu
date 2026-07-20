using DinnerMenuPostgreSQL.Dtos.ReservationDtos;

namespace DinnerMenuPostgreSQL.Service.ReservationServices
{
    public interface IReservationService
    {
        Task<List<ResultReservationDto>> GetAllReservationsAsync();
        Task<GetReservationByIdDto> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(CreateReservationDto createReservationDto);
        Task UpdateReservationAsync(UpdateReservationDto updateReservationDto);
        Task DeleteReservationAsync(int id);
        Task ChangeReservationStatusToPending(int id);
        Task ChangeReservationStatusToApproval(int id);
        Task ChangeReservationStatusToCancel(int id);
    }
}
