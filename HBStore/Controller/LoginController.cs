using HBStore.DTO;
using HBStore.Interface.InterfaceService;
using HBStore.Security;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginDTO model)
        {
            var response = _loginService.Authenticate(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("users");
        }
    }
}