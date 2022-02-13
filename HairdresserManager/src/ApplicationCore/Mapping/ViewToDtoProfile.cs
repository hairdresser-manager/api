using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class ViewToDtoProfile : Profile
    {
        public ViewToDtoProfile()
        {
            CreateMap<AppointmentClientDetailsView, AppointmentClientDetailsDto>()
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.FirstName) ? src.ClientFirstName : src.FirstName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Email) ? src.ClientEmail : src.Email))
                .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.PhoneNumber) ? src.ClientPhoneNumber : src.PhoneNumber));
        }
    }
}