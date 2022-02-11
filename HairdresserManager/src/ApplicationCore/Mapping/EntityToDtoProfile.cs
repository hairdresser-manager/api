using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Schedule, ScheduleDto>()
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));

            CreateMap<ServicesCategory, ServicesCategoryDto>();

            CreateMap<Service, ServiceDto>();
        }
    }
}