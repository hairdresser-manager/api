using ApplicationCore.DTOs;
using ApplicationCore.Results;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class ResultToDtoProfile : Profile
    {
        public ResultToDtoProfile()
        {
            CreateMap<FacebookAuthResult, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}