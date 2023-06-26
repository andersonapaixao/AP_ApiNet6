using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AP_ApiNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserDTO userDTO)
        {
            var result = await _userService.GenerateTokenAsync(userDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
