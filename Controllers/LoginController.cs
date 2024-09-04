using bike_club.Models;
using bike_club.Models.Repositories;
using bike_club.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bike_club.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository _userRepository;
        private IBikeRepository _bikeRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
            _bikeRepository = new BikeRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MUser user)
        {
            if (user.Email == "" || user.PasswordHash == "")
            {
                ModelState.AddModelError("", "Please, introduce the data");
            }


            var userFound = _userRepository.GetByTerm(user.Email, user.PasswordHash);

            if (userFound.RoleId == 1)
            {
                return RedirectToAction("Admin");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(MUser user)
        {
            _userRepository.Update(user);
            return View();
        }

        public IActionResult Admin(MUser user)
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Users = _userRepository.GetAll(),
                Bikes = _bikeRepository.GetAll(),
            };
            return View(loginViewModel);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
