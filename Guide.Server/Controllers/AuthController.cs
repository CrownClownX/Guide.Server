using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Api.ViewModels;
using Guide.BLL.Exceptions;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guide.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Post([FromBody]SignUpDto model)
        {
            var response = new Response<UserDto>();

            try
            {
                response.Object = await _authService.SignUpPlayer(model);
            }
            catch (AlreadyExistException e)
            {
                response.IsError = true;
                response.ErrorMessage = "User with given creditentials already exist";

                _logger.LogError($"AuthController | Error | Error message : {e.Message}");
            }
            catch (PasswordNotValidException e)
            {
                response.IsError = true;
                response.ErrorMessage = "Password is not valid";

                _logger.LogError($"AuthController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]UserCredentialsDto credentials)
        {
            _logger.LogError($"AuthController | Error | INSIDE LOGIN");
            var response = new Response<UserDto>();

            try
            {
                response.Object = await _authService.SignInUser(credentials);
                _logger.LogError($"AuthController | Error | LOGIN SUCCESS");
            }
            catch (PasswordNotValidException e)
            {
                response.IsError = true;
                response.ErrorMessage = "Password is not valid";

                _logger.LogError($"AuthController | Error | Error message : {e.Message}");
            }
            catch (DataNotFoundException e)
            {
                response.IsError = true;
                response.ErrorMessage = "There is no user with given identification";

                _logger.LogError($"AuthController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }
    }
}