using System.Threading.Tasks;
using project_test.Models;

namespace restApi.Services.Users
{
    public class UsersService : IUsersService
    {
        public Task<bool> DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEntity> GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}