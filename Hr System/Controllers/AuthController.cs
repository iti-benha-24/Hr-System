using Hr_System.Models;
using Hr_System.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] TokenReqModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
