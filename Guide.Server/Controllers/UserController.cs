using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Api.ViewModels;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guide.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(long id)
        {
            var response = new Response<UserDto>();

            try
            {
                response.Object = await _userService.GetUser(id);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"UserController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers(int itemPerPage, int page)
        {
            var response = new ResponseCollection<UserDto>();

            try
            {
                response.Objects = await _userService.GetUsers(itemPerPage, page);
            }
            catch(Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"UserController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> NewUser([FromBody]NewUserDto user)
        {
            var response = new Response<UserDto>();

            try
            {
                response.Object = await _userService.CreateUser(user);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"UserController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            var response = new Response<UserDto>();

            try
            {
                response.Object = await _userService.UpdateUser(user);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"UserController | Error | Error message : {e.Message}");
            }

            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            var response = new Response<UserDto>();

            try
            {
                await _userService.DeleteUser(userId);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"UserController | Error | Error message : {e.Message}");
            }

            return Ok();
        }
    }
}