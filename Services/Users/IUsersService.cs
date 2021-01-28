using System.Threading.Tasks;
using project_test.Models;

namespace restApi.Services.Users
{
    public interface  IUsersService
    {
        Task<UserEntity> GetUser(int userId);
        Task<bool> DeleteUser(int userId);
    }
}