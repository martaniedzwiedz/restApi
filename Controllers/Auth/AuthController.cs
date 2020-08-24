using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_test.FacadeModels.Auth;
using project_test.Models;
using project_test.Services.Auth;
using restApi.FacadeModels;

namespace project_test.Controllers.Authorization
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class AuthorizationController : BaseController<IAuthService>
    {
        public AuthorizationController(IAuthService service) : base(service){}

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody]AuthRequest model)
        {
            var token = await _service.Authenticate(model);

            if (token == null)
                return Unauthorized(new {error = 401, message = "Wrong credential provided"});
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]RegisterRequest model)
        {
            var user = await _service.Register(model);
            if(user == null)
                return Conflict(new {error = 409, message = "User already exist"});
            else return Ok(user);
        }
    }
}