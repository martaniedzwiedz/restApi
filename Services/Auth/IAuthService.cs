using project_test.Controllers.Authorization;
using project_test.FacadeModels.Auth;

namespace project_test.Services.Auth
{
    public interface IAuthService 
    {
        AuthResponse Authenticate(AuthRequest authorizationRequest);
    }
}