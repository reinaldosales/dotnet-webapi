using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Services;
using DotnetWebAPI.ViewModels;
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


        [HttpGet("RecoverAllUsers")]
        public async Task<IActionResult> RecoverAllUsers()
        {
            try
            {
                var users = await _userService.RecoverAllUsers();

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
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
                return BadRequest(ex.Message);
            }
        }
    }
}