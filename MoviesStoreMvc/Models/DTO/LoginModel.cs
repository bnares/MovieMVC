using System.ComponentModel.DataAnnotations;

namespace MoviesStoreMvc.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
      
        public string? Password { get; set; }
        
       
    }
}
