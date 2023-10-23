using Microsoft.AspNetCore.Identity;

namespace MoviesStoreMvc.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
