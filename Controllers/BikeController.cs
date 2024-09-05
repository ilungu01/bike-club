using bike_club.Models;
using bike_club.Models.Repositories;
using bike_club.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bike_club.Controllers
{
    public class BikeController : Controller
    {
        private IBikeRepository _bikeRepository;
        private IUserRepository _userRepository;
        public BikeController()
        {
            _bikeRepository = new BikeRepository();
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Add(MBike bike)
        {
            var userId = Request.Form["userId"];
            Guid id = Guid.Parse(userId);
            bike.UserId = id;
            bike.Id = new Guid();
            _bikeRepository.Add(bike);
            return RedirectToAction("AddedWithSuccess", new { id = id });
        }

        public IActionResult Add(Guid id)
        {
            ViewData["userId"] = id;
            return View();
        }

        public IActionResult AddedWithSuccess(Guid id)
        {
            MUser userInfo = _userRepository.GetById(id);
            return View(userInfo);
        }

        public IActionResult Update(Guid bikeId)
        {
            MBike foundBike = _bikeRepository.GetById(bikeId);
            BikeViewModel bikeViewModel = new BikeViewModel()
            {
                Bike = foundBike
            };

            return View(bikeViewModel);
        }

        [HttpPost]
        public IActionResult Update(MBike bike)
        {
            _bikeRepository.Update(bike);

            return RedirectToAction("UpdatedWithSuccess", new { id = bike.UserId });
        }

        public IActionResult UpdatedWithSuccess(Guid id)
        {
            MUser userInfo = _userRepository.GetById(id);
            return View(userInfo);
        }

        public IActionResult Delete(Guid bikeId)
        {
            MBike foundBike = _bikeRepository.GetById(bikeId);
            MUser foundUser = _userRepository.GetById(foundBike.UserId);
            _bikeRepository.Delete(foundBike);
            return View("DeletedWithSuccess", foundUser);
        }

        public IActionResult DeletedWithSuccess(Guid userId)
        {
            return View(_userRepository.GetById(userId));
        }
    }
}
