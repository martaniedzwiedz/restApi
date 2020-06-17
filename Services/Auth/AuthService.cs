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
using restApi.Models;

namespace project_test.Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly AppSettings _appSettings;
        private readonly ModelsContext _modelsContext;
        public AuthService(IOptions<AppSettings> appSettings, ModelsContext modelsContext)
        {
            _appSettings = appSettings.Value;
            _modelsContext = modelsContext;
        }

        public AuthResponse Authenticate(AuthRequest authorizationRequest)
        {
          
            var user = _modelsContext.Users.SingleOrDefault(x  => x.Email == authorizationRequest.Email && x.Password == authorizationRequest.Password);

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