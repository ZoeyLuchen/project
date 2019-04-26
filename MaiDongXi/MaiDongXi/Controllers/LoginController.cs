using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.IRepository;
using MaiDongXi.Entity;
using MaiDongXi.Common;

namespace MaiDongXi.Controllers
{
    public class LoginController : BaseController

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
        public IActionResult Login(string account, string pwd)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
            {
                return JsonError("用户名或密码为空");
            }
            pwd = Md5Helper.MD5Encrypt(pwd, 32);
            var userInfo = _userInfoRepository.GetSingle(e => e.Account == account && e.PassWord == pwd && e.IsDel == false);

            if (userInfo != null)
            {
                //记录Session
                HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(userInfo));
                return JsonOk("", "用户名或密码为空");
            }
            else
            {
                return Json("用户名或密码错误");
            }
        }
    }
}