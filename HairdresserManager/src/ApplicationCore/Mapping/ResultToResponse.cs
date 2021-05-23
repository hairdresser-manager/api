using ApplicationCore.Contract.V1.Jwt.Responses;
using ApplicationCore.Contract.V1.Login.Responses;
using ApplicationCore.Results;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class ResultToResponse : Profile
    {
        public ResultToResponse()
        {
            CreateMap<AuthenticationResult, JwtRefreshResponse>();
            CreateMap<AuthenticationResult, LoginResponse>();
        }
    }
}