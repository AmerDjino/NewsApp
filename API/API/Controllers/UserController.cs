using BLLayer.Interfaces;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
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

        /// <summary>
        /// Returns all active Users
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult<List<UserContract>>> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// Returns active user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserContract>> GetUserById(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest("Invalid UserId - empty ID");
            }
            var result = await _userService.GetUserById(userId);
            return Ok(result);
        }
    }
}
