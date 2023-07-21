using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Domain.ViewModels;
using DotnetWebAPI.Services;
using DotnetWebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace DotnetWebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Serilog.ILogger _logger;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _logger = Log.ForContext<UserController>();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            _logger.ForContext("Payload", JsonConvert.SerializeObject(model)).Information("Login");

            try
            {
                var token = await _userService.Login(model.Name, model.Password);

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.ForContext("Payload", JsonConvert.SerializeObject(model)).Error(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("RecoverAllUsers")]
        [Authorize]
        public async Task<IActionResult> RecoverAllUsers()
        {
            _logger.Information("RecoverAllUsers");

            try
            {
                var users = await _userService.RecoverAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
        [Authorize(Roles = "Admin, Inviter")]
        public async Task<IActionResult> CreateUser(CreateUserModel createUserModel)
        {
            _logger.ForContext("Payload", JsonConvert.SerializeObject(createUserModel)).Information("CreateUser");

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = await _userService.CreateUser(createUserModel);

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.ForContext("Payload", JsonConvert.SerializeObject(createUserModel)).Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.ForContext("Payload", JsonConvert.SerializeObject(id)).Information("DeleteUser");

            try
            {
                var user = await _userService.DeleteUser(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.ForContext("Payload", JsonConvert.SerializeObject(id)).Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}