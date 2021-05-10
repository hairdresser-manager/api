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

            CreateMap<Employee, EmployeeDto>();

            CreateMap<User, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Schedule, ScheduleDto>()
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));
            
            CreateMap<ServicesCategory, ServicesCategoryDto>();
        }
    }
}