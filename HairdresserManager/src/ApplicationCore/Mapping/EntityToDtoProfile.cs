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

            CreateMap<Appointment, AppointmentDto>();
            
            CreateMap<Appointment, AppointmentEmployeeDetailsDto>()
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.EmployeeNick, opt => opt.MapFrom(src => src.Employee.Nick))
                .ForMember(dest => dest.EmployeeLowQualityAvatar, opt => opt.MapFrom(src => src.Employee.LowQualityAvatarUrl))
                .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.Review.Id))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Review.Rate));
        }
    }
}