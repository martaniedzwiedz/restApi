using System.ComponentModel.DataAnnotations;

namespace project_test.FacadeModels.Auth
{
    public class AuthRequest
    {
        [Required]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
    }
}