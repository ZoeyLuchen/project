using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.Models;
using MaiDongXi.IRepository;
using MaiDongXi.Entity;

namespace MaiDongXi.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var list = _userRepository.GetAll().ToList();
            ViewBag.UserList = list;
            return View();
        }

        public IActionResult Add(User model)
        {
            _userRepository.Add(model);
            _userRepository.Commit();

            return Json("");
        }
    }
}
