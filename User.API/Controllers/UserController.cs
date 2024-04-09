using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Business.DTOs.Response;
using User.Business.Services;

namespace User.API.Controllers
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
        // GET: api/User
        [HttpGet]
        public IActionResult Get(int id)
        {
            UserResponseDTO? userDto = _userService.GetUser(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

    }
}
