using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Authentication.Jwt.Requests;
using ApplicationCore.Contract.V1.Authentication.Jwt.Responses;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.User
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "User / Authentication / Jwt")]
    public class JwtController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly IMapper _mapper;

        public JwtController(IJwtManager jwtManager, IMapper mapper)
        {
            _jwtManager = jwtManager;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.RefreshToken.Refresh)]
        public async Task<IActionResult> RefreshToken([FromBody] JwtRefreshRequest request)
        {
            var authenticationResult = await _jwtManager.RefreshTokensAsync(request.AccessToken, request.RefreshToken);

            if (!authenticationResult.Succeeded)
                return BadRequest(new ErrorResponse(authenticationResult.Errors));

            var response = _mapper.Map<JwtRefreshResponse>(authenticationResult);
            return Ok(response);
        }
    }
}