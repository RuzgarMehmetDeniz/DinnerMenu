using DinnerMenuPostgreSQL.Dtos.OrderDtos;
using DinnerMenuPostgreSQL.Service.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderList(int page = 1, int? year = null, int? month = null)
        {
            int pageSize = 10;

            // Eğer kullanıcı ay/yıl seçmediyse, içinde bulunulan ayı varsayılan yap
            var selectedYear = year ?? DateTime.Now.Year;
            var selectedMonth = month ?? DateTime.Now.Month;

            var pagedOrders = await _orderService.GetAllOrdersAsync(page, pageSize, selectedYear, selectedMonth);

            ViewBag.SelectedYear = selectedYear;
            ViewBag.SelectedMonth = selectedMonth;

            return View(pagedOrders);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            ViewBag.Products = await _orderService.GetProductsForSelectAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateOrderAsync(createOrderDto);
            return RedirectToAction("OrderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _orderService.UpdateOrderAsync(updateOrderDto);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> ChangeStatusToPreparing(int id)
        {
            await _orderService.ChangeOrderStatusToPreparing(id);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> ChangeStatusToServed(int id)
        {
            await _orderService.ChangeOrderStatusToServed(id);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> ChangeStatusToCancel(int id)
        {
            await _orderService.ChangeOrderStatusToCancel(id);
            return RedirectToAction("OrderList");
        }
    }
}