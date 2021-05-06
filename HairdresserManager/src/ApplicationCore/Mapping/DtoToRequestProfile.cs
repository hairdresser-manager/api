using ApplicationCore.Contract.V1.Employee.Responses;
using ApplicationCore.Contract.V1.Login.Responses;
using ApplicationCore.DTOs;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class DtoToRequestProfile : Profile
    {
        public DtoToRequestProfile()
        {
            CreateMap<UserDto, LoginResponse>();
            CreateMap<EmployeeDto, EmployeeResponse>();
            CreateMap<UserDto, EmployeeResponse>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, 
                    opt => opt.MapFrom(src => src.MobilePhone));
        }
    }
}