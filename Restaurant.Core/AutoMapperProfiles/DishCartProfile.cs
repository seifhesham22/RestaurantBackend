using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.AutoMapperProfiles
{
    public class DishCartProfile : Profile
    {
        public DishCartProfile()
        {
            CreateMap<DishCartDto, DishCart>();
            CreateMap<DishCart, DishCartDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Dish.Image))  // dest => destination, opt => options(conditions), src => source 
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Dish.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src =>src.Dish.Price))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Dish.Price));
               
        }
    }
}
