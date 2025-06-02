using AutoMapper;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser , UserRegisterDto>();
            CreateMap<UserRegisterDto , ApplicationUser>();
            CreateMap<UserEditDto , ApplicationUser>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
