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
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;

        public LoginController(IIdentityService identityService, IMapper mapper, IJwtManager jwtManager)
        {
            _identityService = identityService;
            _mapper = mapper;
            _jwtManager = jwtManager;
        }

        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userDto = await _identityService.GetUserDtoByCredentialsAsync(request.Email, request.Password);

            if (userDto == null)
                return BadRequest(new ErrorResponse("user doesn't exist or credentials are wrong"));

            if (!userDto.EmailConfirmed)
                return BadRequest(new ErrorResponse("email isn't verified"));

            var authenticationResult = await _jwtManager.CreateAuthenticationResultAsync(userDto);
            var response = _mapper.Map<LoginResponse>(userDto);
            _mapper.Map(authenticationResult, response);

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
    }
}