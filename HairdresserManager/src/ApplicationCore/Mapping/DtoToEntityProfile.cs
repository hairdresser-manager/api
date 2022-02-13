using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<EmployeeDto, Employee>();

            CreateMap<ServicesCategoryDto, ServicesCategory>();
            
            CreateMap<ServiceDto, Service>();

            CreateMap<AppointmentDto, Appointment>();
            
            CreateMap<ReviewDto, Review>();
        }
    }
}