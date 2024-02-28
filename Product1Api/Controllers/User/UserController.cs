using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices;
using Product1Api.Common.ApplicationServices.User;
using Product1Api.Common.Models.User;

namespace Product1Api.Controllers.User
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSer _userSer;

        public UserController(IUserSer userSer)
        {
            _userSer = userSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        [HttpPost("SignUp")]
        public async Task<IActionResult> POST([FromForm] UserDto userDto)
        {
            try
            {
                _userSer.signup(userDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("User", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}
