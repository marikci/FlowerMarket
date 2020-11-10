using AutoMapper;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;

namespace FlowerMarket.Model.Mappers
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<StockRoomStock, StockRoomStockDto>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.StockRoomId, opts => opts.MapFrom(src => src.StockRoomId))
                .ForMember(dest => dest.StockRoomStockId, opts => opts.MapFrom(src => src.StockRoomStockId));
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.AccountId, opts => opts.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.CartId, opts => opts.MapFrom(src => src.CartId))
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Quantity));
            CreateMap<CartDto, Cart>()
               .ForMember(dest => dest.AccountId, opts => opts.MapFrom(src => src.AccountId))
               .ForMember(dest => dest.CartId, opts => opts.MapFrom(src => src.CartId))
               .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId))
               .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Quantity));
            CreateMap<Account, AccountDto>()
              .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
              ;
        }
    }
}
