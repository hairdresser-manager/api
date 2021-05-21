using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Login.Requests;
using ApplicationCore.Contract.V1.Login.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public LoginController(IJwtService jwtService, IIdentityService identityService, IMapper mapper,
            IRefreshTokenService refreshTokenService)
        {
            _jwtService = jwtService;
            _identityService = identityService;
            _mapper = mapper;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userDto = await _identityService.GetUserDtoByCredentialsAsync(request.Email, request.Password);

            if (userDto == null)
                return BadRequest(new ErrorResponse("user doesn't exist or credentials are wrong"));

            if (!userDto.EmailConfirmed)
                return BadRequest(new ErrorResponse("email isn't verified"));

            var response = await CreateLoginResponseAsync(userDto);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public IActionResult FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var fakeResponse = new LoginResponse
            {
                AccessToken = "not-implemented-yet",
                RefreshToken = "not-implemented-yet"
            };

            return Ok(fakeResponse);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return NoContent();
        }

        private async Task<LoginResponse> CreateLoginResponseAsync(UserDto userDto)
        {
            var jti = Guid.NewGuid();
            var accessToken = _jwtService.CreateAccessToken(userDto, jti);
            var refreshToken = await _refreshTokenService.CreateRefreshTokenAsync(userDto.Id, jti);

            var response = _mapper.Map<LoginResponse>(userDto);
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;

            return response;
        }
    }
}