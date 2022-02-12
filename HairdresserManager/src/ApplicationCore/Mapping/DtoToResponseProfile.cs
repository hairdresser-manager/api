using ApplicationCore.Contract.V1.Account.Responses;
using ApplicationCore.Contract.V1.Client.Appointment.Responses;
using ApplicationCore.Contract.V1.Employee.Responses;
using ApplicationCore.Contract.V1.Login.Responses;
using ApplicationCore.Contract.V1.Offer;
using ApplicationCore.DTOs;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class DtoToResponseProfile : Profile
    {
        public DtoToResponseProfile()
        {
            CreateMap<UserDto, LoginResponse>();

            CreateMap<EmployeeDto, EmployeeResponse>();

            CreateMap<EmployeeDto, GetTeamMemberResponse>()
                .ForMember(dest => dest.EmployeeId,
                    opt => opt.MapFrom(src => src.Id));

            CreateMap<UserDto, EmployeeResponse>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.MobilePhone));

            CreateMap<UserDto, GetUserDataResponse>();

            CreateMap<EmployeeDto, FreeDateResponse>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Nick))
                .ForMember(dest => dest.EmployeeLowQualityAvatarUrl,
                    opt => opt.MapFrom(src => src.LowQualityAvatarUrl));

            CreateMap<FreeDateDto, FreeDateResponse>()
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeName, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeLowQualityAvatarUrl, opt => opt.Ignore())
                .ForMember(dest => dest.AvailableDates, opt => opt.MapFrom(src => src.DateHoursDto));

            CreateMap<DateHoursDto, DateHoursResponse>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));

            CreateMap<AppointmentEmployeeDetailsDto, GetAppointmentListMemberResponse>();
        }
    }
}