using BLLayer.Interfaces;
using Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<ActionResult<UserContract>> RegisterUser(RegistrationContract registrationContract)
        {
           var result = await _accountService.RegisterUser(registrationContract);
           return Ok(result);
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserContract>> Login(LoginContract loginContract)
        {
           var result = await _accountService.Login(loginContract);
            return Ok(result);
        }
    }
}
