using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;
using InsteadBuyPlatform.Entity;

namespace InsteadBuyPlatform.Controllers
{
    public class HomeController : BaseController
    {
        IUserInfoRepository _userInfoRepository;

        public HomeController(IUserInfoRepository userInfoRepository) {
            _userInfoRepository = userInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home() {
            return View();
        }
    }
}
