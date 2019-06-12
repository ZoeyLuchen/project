using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SexShop.Controllers
{
    public class SysGoodsInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGoods()
        {
            return Json("");
        }
    }
}