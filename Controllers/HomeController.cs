using bike_club.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bike_club.Models.Repositories;
using bike_club.ViewModels;
using Microsoft.Identity.Client;

namespace bike_club.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserRepository _userRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ViewMembers()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Users = _userRepository.GetAll(),
            };

            return View(homeViewModel);
        }
    }
}