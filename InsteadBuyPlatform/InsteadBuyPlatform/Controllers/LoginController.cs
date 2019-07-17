using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Common;
using Microsoft.AspNetCore.Session;
using System.Text.RegularExpressions;

namespace InsteadBuyPlatform.Controllers
{
    public class LoginController : BaseController

    {
        IUserInfoRepository _userInfoRepository;
        ISmsCodeInfoRepository _smsCodeInfoRepository;

        public LoginController(IUserInfoRepository userInfoRepository,
            ISmsCodeInfoRepository smsCodeInfoRepository,
            ICouponInfoRepository couponInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _smsCodeInfoRepository = smsCodeInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IActionResult GetSmsCode(string phone)
        {
            if (!Regex.IsMatch(phone, @"^1\d{10}$"))
            {
                return JsonError("手机格式不正确");
            }

            var model = _smsCodeInfoRepository.FindBy(e => e.IsUse == 0 && e.Phone == phone).FirstOrDefault();
            //成本考虑，如果验证码未过期,不重新发送验证码
            if (model != null && DateTime.Now < model.ExpirationTime)
            {
                return JsonError("验证码已发送");
            }

            var code = RandomHelper.GenerateRandomCode(6);
            //TODO:调用阿里接口发送短信
            model = new SmsCodeInfo()
            {
                Code = code,
                CreateTime = DateTime.Now,
                ExpirationTime = DateTime.Now.AddMinutes(10),
                IsUse = 0,
                Phone = phone,
                Type = 1
            };
            _smsCodeInfoRepository.Add(model);

            return JsonOk("发送成功");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public IActionResult Login(string phone, string code)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return JsonError("手机号不能为空");
            }
            if (string.IsNullOrEmpty(code))
            {
                return JsonError("验证码不能为空");
            }
            var smsCodeModel = _smsCodeInfoRepository.FindBy(e => e.IsUse == 0 && e.Phone == phone).FirstOrDefault();

            if (smsCodeModel != null && smsCodeModel.ExpirationTime < DateTime.Now)
            {
                return JsonError("请先发送验证码");
            }

            if (smsCodeModel.Code != code)
            {
                return JsonError("验证码不正确");
            }
            else
            {
                smsCodeModel.IsUse = 1;
                _smsCodeInfoRepository.Update(smsCodeModel);
            }

            var userInfo = _userInfoRepository.GetSingle(e => e.Account == phone && e.IsDel == 0);

            if (userInfo == null)
            {
                userInfo = new UserInfo()
                {
                    Account = phone,
                    CreateTime = DateTime.Now,
                    Img = "",
                    InvitationCode = RandomHelper.GenerateRandomCode(6),
                    BeInvitationCode = "",
                    IsDel = 0,
                    Old = "0",
                    Sex = "",
                    UpdateTime = DateTime.Now,
                    UserName = "贝贝" + RandomHelper.GenerateRandomCode(3)
                };
                var bo = _userInfoRepository.AddUserInfo(userInfo);

                if (!bo)
                {
                    JsonError("登录失败");
                }
            }

            CurrentUserInfo currentUserInfo = new CurrentUserInfo()
            {
                Id = userInfo.Id,
                Account = userInfo.Account,
                UserName = userInfo.UserName,
                PermissionList = new List<dynamic>()
            };

            //记录Session
            HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(currentUserInfo));

            return JsonOk("登录成功");
        }
    }
}