using MoviesStoreMvc.Models.DTO;

namespace MoviesStoreMvc.Repositories.Abstract
{
    public interface IUserAutenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
    }
}
