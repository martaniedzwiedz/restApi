using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_test.FacadeModels.Auth;
using project_test.Services.Auth;

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
        public IActionResult Authenticate([FromBody]AuthRequest model)
        {
            var token = _service.Authenticate(model);

            if (token == null)
                return Unauthorized(new {message = "Wrong credential provided"});
            return Ok(token);
        }
    }
}