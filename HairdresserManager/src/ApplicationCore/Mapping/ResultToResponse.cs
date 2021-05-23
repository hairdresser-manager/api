using ApplicationCore.Contract.V1.Jwt.Responses;
using ApplicationCore.Results;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class ResultToResponse : Profile
    {
        public ResultToResponse()
        {
            CreateMap<AuthenticationResult, JwtRefreshResponse>();
        }
    }
}