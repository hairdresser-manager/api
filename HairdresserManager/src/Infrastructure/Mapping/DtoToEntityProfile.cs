using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.MobilePhone))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EmployeeDto, Employee>();
        }
    }
}