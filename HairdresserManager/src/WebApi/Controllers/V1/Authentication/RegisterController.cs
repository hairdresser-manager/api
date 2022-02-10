using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication / Register")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IIdentityService _identity;
        private readonly IMapper _mapper;

        public RegisterController(IUserService userService, IClientService clientService, IIdentityService identity,
            IMapper mapper)
        {
            _userService = userService;
            _clientService = clientService;
            _identity = identity;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Register.RegisterUser)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _userService.UserExistsAsync(request.Email))
                return BadRequest(new ErrorResponse("user already exists"));

            var userDto = _mapper.Map<UserDto>(request);
            
            var (result, userId, verifyToken) = await _userService.CreateUserAsync(userDto, request.Password);

            if (!result.Succeeded)
                return BadRequest(new ErrorResponse(result.Errors));

            var added = await _clientService.AddUserToClientsAsync(userId);

            return added ? Ok(new {VerifyToken = verifyToken}) : BadRequest(new ErrorResponse("Something went wrong"));
        }

        [HttpPost(ApiRoutes.Register.VerifyEmail)]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            var result = await _identity.VerifyEmailAsync(request.Email, request.Token);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}