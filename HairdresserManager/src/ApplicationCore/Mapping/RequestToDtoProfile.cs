using ApplicationCore.Contract.V1.Account.Requests;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.DTOs;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class RequestToDtoProfile : Profile
    {
        public RequestToDtoProfile()
        {
            CreateMap<RegisterRequest, UserDto>();   
            CreateMap<UpdateAccountRequest, UserDto>();   
        }
    }
}