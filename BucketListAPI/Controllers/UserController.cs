using bucketListAPIModels;
using bucketListService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BucketListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel loginModel)
        {
            //moostee has edited this.
            return Ok(_userService.AuthenticateUser(loginModel));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public IActionResult SignUpUser([FromBody]User signup)
        {

            return Ok(_userService.SignUpUser(signup));
        }


    }
}
