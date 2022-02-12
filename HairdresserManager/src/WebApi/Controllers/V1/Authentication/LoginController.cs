using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Authentication.Login.Requests;
using ApplicationCore.Contract.V1.Authentication.Login.Responses;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication / Login")]
    public class LoginController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;
        private readonly IFacebookAuthService _facebookAuthService;

        public LoginController(IIdentityService identityService, IMapper mapper, IJwtManager jwtManager,
            IFacebookAuthService facebookAuthService, IUserService userService)
        {
            _identityService = identityService;
            _mapper = mapper;
            _jwtManager = jwtManager;
            _facebookAuthService = facebookAuthService;
            _userService = userService;
        }

        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userDto = await _identityService.GetUserDtoByCredentialsAsync(request.Email, request.Password);

            if (userDto == null)
                return BadRequest(new ErrorResponse("user doesn't exist or credentials are wrong"));

            if (!userDto.EmailConfirmed)
                return BadRequest(new ErrorResponse("email isn't verified"));
            
            return await GetAuthenticationResponseAsync(userDto);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public async Task<IActionResult> FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var facebookAuthResponse = await _facebookAuthService.AuthUserByFbTokenAsync(request.AccessToken);

            if (facebookAuthResponse.Success == false)
                BadRequest(new ErrorResponse(facebookAuthResponse.ErrorMessage));

            var userDto = await _userService.GetUserDtoByEmailAsync(facebookAuthResponse.Email);

            if (userDto != null) 
                return await GetAuthenticationResponseAsync(userDto);
            
            userDto = _mapper.Map<UserDto>(facebookAuthResponse);
            await _userService.CreateExternalServiceUserAsync(userDto);

            return await GetAuthenticationResponseAsync(userDto);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return NoContent();
        }

        private async Task<IActionResult> GetAuthenticationResponseAsync(UserDto userDto)
        {
            var authenticationResult = await _jwtManager.CreateAuthenticationResultAsync(userDto);
            var response = _mapper.Map<LoginResponse>(userDto);
            
            _mapper.Map(authenticationResult, response);

            return Ok(response);
        }
    }
}