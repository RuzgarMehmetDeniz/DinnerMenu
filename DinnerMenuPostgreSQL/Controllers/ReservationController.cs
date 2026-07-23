using DinnerMenuPostgreSQL.Dtos.ReservationDtos;
using DinnerMenuPostgreSQL.Service.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CreateReservationDto());
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            // 1. Status değerini Controller tarafında "Beklemede" olarak belirle
            createReservationDto.Status = "Beklemede";

            // 2. Müşteri formunda Status girdisi olmadığı için oluşan validation hatasını temizle
            ModelState.Remove("Status");

            // 3. Validation kontrolünü hata temizlendikten SONRA yap
            if (!ModelState.IsValid)
            {
                return View(createReservationDto);
            }

            try
            {
                // 4. PostgreSQL için UTC tarih formatı dönüşümü
                createReservationDto.ReservationDate = DateTime.SpecifyKind(createReservationDto.ReservationDate, DateTimeKind.Utc);

                // 5. Servis üzerinden veritabanına kaydet
                await _reservationService.CreateReservationAsync(createReservationDto);

                ViewBag.ReservationSuccess = true;

                // Başarılı işlem sonrası boş form döndür
                return View(new CreateReservationDto());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Rezervasyon oluşturulurken bir hata oluştu: " + ex.Message);
                return View(createReservationDto);
            }
        }
        public async Task<IActionResult> ReservationList()
        {
            var values = await _reservationService.GetAllReservationsAsync();
            return View(values);
        }

        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            createReservationDto.ReservationDate = DateTime.SpecifyKind(createReservationDto.ReservationDate, DateTimeKind.Utc);
            await _reservationService.CreateReservationAsync(createReservationDto);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var value = await _reservationService.GetReservationByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            updateReservationDto.ReservationDate = DateTime.SpecifyKind(updateReservationDto.ReservationDate, DateTimeKind.Utc);
            await _reservationService.UpdateReservationAsync(updateReservationDto);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> ApproveReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToApproval(id);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> PendingReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToPending(id);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            await _reservationService.ChangeReservationStatusToCancel(id);
            return RedirectToAction("ReservationList");
        }
    }
}
