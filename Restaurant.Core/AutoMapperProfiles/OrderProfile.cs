using AutoMapper;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderInfoDto>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.DishCarts));
        }
    }
}
