using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.MobilePhone,
                    opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<User, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}