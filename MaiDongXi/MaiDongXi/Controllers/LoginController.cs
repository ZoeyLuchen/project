using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.IRepository;
using MaiDongXi.Entity;
using MaiDongXi.Common;
using Microsoft.AspNetCore.Session;

namespace MaiDongXi.Controllers
{
    public class LoginController : Controller

    {
        IUserInfoRepository _userInfoRepository;

        public LoginController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string passWord,string account)
        {

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(passWord))
            {
                return Json(new { code = 500, message = "用户名或密码为空" });
            }
            passWord = Md5Helper.MD5Encrypt(passWord, 32);
            var userInfo = _userInfoRepository.GetSingle(e => e.Account == account && e.PassWord == passWord && e.IsDel == 0);

            if (userInfo != null)
            {
                CurrentUserInfo currentUserInfo = new CurrentUserInfo() {
                    Id = userInfo.Id,
                    Account = userInfo.Account,
                    UserName = userInfo.UserName,
                    PermissionList = new List<dynamic>()
                };

                //记录Session
                HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(currentUserInfo));               

                return Json(new { code = 200, message = "登录成功" });
            }
            else
            {
                return Json(new { code = 500, message = "用户名或密码错误" });
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}