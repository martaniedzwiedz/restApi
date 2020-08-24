using System.ComponentModel.DataAnnotations;

namespace restApi.FacadeModels
{
    public class RegisterRequest
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
    }
}