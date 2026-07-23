using AutoMapper;
using DinnerMenuPostgreSQL.Dtos.CategoryDtos;
using DinnerMenuPostgreSQL.Dtos.OrderDtos;
using DinnerMenuPostgreSQL.Dtos.OrderItemDtos;
using DinnerMenuPostgreSQL.Dtos.ProductDtos;
using DinnerMenuPostgreSQL.Dtos.ReservationDtos;
using DinnerMenuPostgreSQL.Dtos.ReviewDtos;
using DinnerMenuPostgreSQL.Entities;

namespace DinnerMenuPostgreSQL.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();

            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();

            CreateMap<Review, ResultReviewDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, GetReviewByIdDto>().ReverseMap();


            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderByIdDto>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemByIdDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, ResultOrderItemDto>().ReverseMap();
        }
    }
}
