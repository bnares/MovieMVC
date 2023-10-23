using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MoviesStoreMvc.Models.DTO
{
    public class RegistrationModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string Role { get; set; }


    }
}
