using System.Threading.Tasks;
using project_test.Controllers.Authorization;
using project_test.FacadeModels.Auth;
using project_test.Models;
using restApi.FacadeModels;

namespace project_test.Services.Auth
{
    public interface IAuthService 
    {
        Task<AuthResponse> Authenticate(AuthRequest authorizationRequest);
        Task<UserEntity> Register(RegisterRequest registration);
    }
}