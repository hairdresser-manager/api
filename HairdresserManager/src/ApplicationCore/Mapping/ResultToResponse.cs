using ApplicationCore.Contract.V1.Authentication.Jwt.Responses;
using ApplicationCore.Contract.V1.Authentication.Login.Responses;
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