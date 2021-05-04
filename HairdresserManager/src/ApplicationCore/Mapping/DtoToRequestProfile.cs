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
        }
    }
}