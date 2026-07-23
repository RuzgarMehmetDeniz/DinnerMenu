using AutoMapper;
using DinnerMenuPostgreSQL.Context;
using DinnerMenuPostgreSQL.Dtos.OrderDtos;
using DinnerMenuPostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DinnerMenuPostgreSQL.Service.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                TableNumber = createOrderDto.TableNumber,
                CustomerName = createOrderDto.CustomerName,
                Description = createOrderDto.Description,
                OrderDate = DateTime.Now,
                Status = "Beklemede",
                OrderItems = new List<OrderItem>()
            };

            decimal total = 0;

            foreach (var item in createOrderDto.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                    continue; // gecersiz ProductId sessizce atlanir

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price // siparis anindaki fiyat donduruluyor
                };

                total += product.Price * item.Quantity;
                order.OrderItems.Add(orderItem);
            }

            order.TotalPrice = total;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResultDto<ResultOrderDto>> GetAllOrdersAsync(int pageNumber = 1, int pageSize = 10, int? year = null, int? month = null)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .AsQueryable();

            if (year.HasValue)
                query = query.Where(o => o.OrderDate.Year == year.Value);

            if (month.HasValue)
                query = query.Where(o => o.OrderDate.Month == month.Value);

            query = query.OrderByDescending(o => o.OrderId);

            var totalCount = await query.CountAsync();

            var orders = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mapped = _mapper.Map<List<ResultOrderDto>>(orders);

            return new PagedResultDto<ResultOrderDto>
            {
                Items = mapped,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<GetOrderByIdDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            return _mapper.Map<GetOrderByIdDto>(order);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders.FindAsync(updateOrderDto.OrderId);
            if (order == null) return;

            order.TableNumber = updateOrderDto.TableNumber;
            order.CustomerName = updateOrderDto.CustomerName;
            order.Description = updateOrderDto.Description;

            await _context.SaveChangesAsync();
        }

        public async Task ChangeOrderStatusToPreparing(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;

            order.Status = "Hazırlanıyor";
            await _context.SaveChangesAsync();
        }

        public async Task ChangeOrderStatusToServed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;

            order.Status = "Servis Edildi";
            await _context.SaveChangesAsync();
        }

        public async Task ChangeOrderStatusToCancel(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;

            order.Status = "İptal Edildi";
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProductSelectDto>> GetProductsForSelectAsync()
        {
            return await _context.Products
                .Where(p => p.Status)
                .OrderBy(p => p.ProductName)
                .Select(p => new ProductSelectDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price
                })
                .ToListAsync();
        }
    }
}
