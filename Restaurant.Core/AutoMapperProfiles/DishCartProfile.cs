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
    public class DishCartProfile : Profile
    {
        public DishCartProfile()
        {
            CreateMap<DishCartDto, DishCart>();
            CreateMap<DishCart , DishCartDto>();
        }
    }
}
