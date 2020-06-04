using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using project_test.FacadeModels.Auth;
using project_test.Helpers;
using project_test.Models;

namespace project_test.Services.Auth
{
    public class AuthService : IAuthService
    {

          private List<UserEntity> _users = new List<UserEntity>
        { 
            new UserEntity { Id = 1, FirstName = "Test", LastName = "User", Email = "test", Password = "test" } 
        };

        private readonly AppSettings _appSettings;
        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthResponse Authenticate(AuthRequest authorizationRequest)
        {
            var user = _users.SingleOrDefault(x => x.Email == authorizationRequest.Email && x.Password == authorizationRequest.Password);

            if (user == null)
              return null;

           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
         
            AuthResponse authResponse = new AuthResponse();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            authResponse.Token = tokenHandler.WriteToken(token);
        
            return authResponse;
        }
    }
}