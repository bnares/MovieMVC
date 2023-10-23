using Microsoft.AspNetCore.Mvc;
using MoviesStoreMvc.Models.DTO;
using MoviesStoreMvc.Repositories.Abstract;

namespace MoviesStoreMvc.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAutenticationService _userAutenticationService;
        public UserAuthenticationController(IUserAutenticationService userAutenticationService)
        {
            _userAutenticationService= userAutenticationService;
        }

        public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@o2.pl",
                Username = "admin",
                Name = "Piotr",
                Password = "Pa$$w0rd",
                PasswordConfirm = "Pa$$w0rd",
                Role = "Admin"

            };
            var result = await _userAutenticationService.RegisterAsync(model);
            return Ok(result.Message);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            }
            var result = await _userAutenticationService.LoginAsync(model);
            if(result.StatusCode == 1)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in... cutom message";
                return RedirectToAction(nameof(Login));
            }
            
        }

        public async Task<IActionResult> Logout()
        {
            await _userAutenticationService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }


    }
}
