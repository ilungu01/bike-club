using bike_club.Models;
using bike_club.Models.Repositories;
using bike_club.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bike_club.Controllers
{
    public class UserController : Controller
    {

        IUserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public IActionResult Update(Guid userId)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                User = _userRepository.GetById(userId)
            };

            return View(userViewModel);
        }

        public IActionResult Delete(Guid userId)
        {
            _userRepository.Delete(_userRepository.GetById(userId));
            return View("DeletedWithSuccess");
        }

        public IActionResult DeletedWithSuccess()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CreatedWithSuccess()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(MUser user)
        {
            var userToAdd = user;
            userToAdd.Role = new MRole()
            {
                Name = "authenicated_user",
                Description = "Authenticated user has access to modify his profile"
            };
            _userRepository.Add(userToAdd);
            return RedirectToAction("CreatedWithSuccess");
        }
    }
}
