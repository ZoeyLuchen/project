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
        IUserInfoRepository _userInfoRepository;

        public HomeController(IUserInfoRepository userInfoRepository) {
            _userInfoRepository = userInfoRepository;
        }

        public IActionResult Index()
        {
            var list = _userInfoRepository.GetAll().ToList();
            ViewBag.UserList = list;
            return View();
        }

        public IActionResult Add(UserInfo model)
        {
            _userInfoRepository.Add(model);
            _userInfoRepository.Commit();

            return Json("");
        }
    }
}
