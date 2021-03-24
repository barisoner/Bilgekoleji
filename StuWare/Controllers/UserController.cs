using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StuWare.Data.Repository;
using StuWare.Helpers;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public object FormsAuthentication { get; private set; }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User entity)
        {

            var user = _userRepository.Login(entity.Email, entity.Password);
            var check = _userRepository.Users.FirstOrDefault(x => x.Email == entity.Email && x.Password == entity.Password);

            if (user != null)
            {
                if (check != null)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Email", user.Email);
                    TempData["Username"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Error"] = "Hatalı Giriş";

            }


            return RedirectToAction("Index", "User");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User entity)
        {
            if (ModelState.IsValid)
            {
                _userRepository.CreateUser(entity);
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View(entity);
            }

        }
    }
}
