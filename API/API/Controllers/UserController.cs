using BLLayer.Interfaces;
using Contracts;
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

        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public async Task<List<UserContract>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        // GET api/<UserController>/5
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
