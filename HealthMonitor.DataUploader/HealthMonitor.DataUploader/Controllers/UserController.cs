using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthMonitor.DataUploader.DAL;
using HealthMonitor.DataUploader.Models;
using HealthMonitor.DataUploader.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthMonitor.DataUploader.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = new List<UserViewModel>();
            var users = _unitOfWork.userRepository.GetAllUsers();
            foreach (var user in users)
            {
                var vm = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    BloodPressure = user.UserDetails.OrderByDescending(d=>d.TrackingDate).FirstOrDefault().BloodPressureRate.ToString(),
                    CreatineLevel = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().CreatineLevel.ToString(),
                    GlucoseLevel = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().BloodSugarRate.ToString(),
                    HeartRate = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().HeartBeatRate.ToString(),
                    Date = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().TrackingDate
                };

                result.Add(vm);
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _unitOfWork.userRepository.GetUser(id);
            var model = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                BloodPressure = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().BloodPressureRate.ToString(),
                CreatineLevel = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().CreatineLevel.ToString(),
                GlucoseLevel = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().BloodSugarRate.ToString(),
                HeartRate = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().HeartBeatRate.ToString(),
                Date = user.UserDetails.OrderByDescending(d => d.TrackingDate).FirstOrDefault().TrackingDate
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel model)
        {
            var usr = _unitOfWork.userRepository.GetUser(model.Id);

            usr.Name = model.Name;
            var usrdtls = new UserDetails()
            {
                BloodPressureRate = Convert.ToInt32(model.BloodPressure),
                CreatineLevel = Convert.ToDouble(model.CreatineLevel),
                BloodSugarRate = Convert.ToInt32(model.GlucoseLevel),
                HeartBeatRate = Convert.ToInt32(model.HeartRate),
                TrackingDate = DateTime.Now
            };
            usr.UserDetails.Add(usrdtls);

           bool result =  _unitOfWork.userRepository.UpdateUser(usr);
            if (result)
                return RedirectToAction("Index");
            return View();
        }

        public IActionResult Delete(int id)
        {
            _unitOfWork.userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var model = new UserAddViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddUser(UserAddViewModel model)
        {


            var usr = new User()
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
            };
            var usrdtls = new UserDetails()
            {
                BloodPressureRate = Convert.ToInt32(model.BloodPressure),
                CreatineLevel = Convert.ToDouble(model.CreatineLevel),
                BloodSugarRate = Convert.ToInt32(model.GlucoseLevel),
                HeartBeatRate = Convert.ToInt32(model.HeartRate),
                TrackingDate = DateTime.Now
            };
            usr.UserDetails.Add(usrdtls);
            _unitOfWork.userRepository.AddUser(usr);
            return RedirectToAction("Index");
        }
    }
}
