using Microsoft.AspNetCore.Mvc;
using Paradigmi.Library.Application.Factories;
using Paradigmi.Library.Application.Models.Requests;
using Paradigmi.Library.Application.Models.Response;
using Paradigmi.Library.Application.Abstractions.Services;

namespace Paradigmi.Library.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn([FromBody] SignInRequest request)
        {
            var user = request.ToEntity();
            if (_userService.SignIn(user.Name, user.Surname, user.Email, user.Password))
            {
                var response = new SignInResponse();
                response.User = new Application.Models.Dtos.UserDto(user);
                return Ok(ResponseFactory.WithSuccess(response));
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _userService.LogIn(request.Email, request.Password);
            if (token == null)
                return BadRequest(ResponseFactory.WithError("wrong credentials"));
            else
                return Ok(new LoginResponse(token));
        }
    }
}
