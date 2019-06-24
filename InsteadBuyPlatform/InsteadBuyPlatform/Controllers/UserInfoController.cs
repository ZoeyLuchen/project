using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;
using InsteadBuyPlatform.Entity;

namespace InsteadBuyPlatform.Controllers
{
    public class UserInfoController : BaseController
    {
        IUserInfoRepository _userInfoRepository;
        IUserCouponRepository _userCouponRepository;
        ICouponInfoRepository _couponInfoRepository;

        public UserInfoController(IUserInfoRepository userInfoRepository, 
            IUserCouponRepository userCouponRepository,
            ICouponInfoRepository couponInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _userCouponRepository = userCouponRepository;
            _couponInfoRepository = couponInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public IActionResult GetModel()
        {
            var userId = CurrentUser.Id;

            return JsonOk(_userInfoRepository.GetSingle(userId));
        }

        /// <summary>
        /// 设置被邀请码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IActionResult SetBeInvitationCode(string code)
        {
            try
            {
                var userModel = _userInfoRepository.FindBy(e => e.InvitationCode == code && e.IsDel == false).FirstOrDefault();
                if (userModel != null)
                {
                    var myUserId = CurrentUser.Id;
                    var myUser = _userInfoRepository.GetSingle(myUserId);
                    myUser.BeInvitationCode = code;
                    _userInfoRepository.Update(myUser);

                    var couponModel = _couponInfoRepository.FindBy(e => e.CouponType == "000001" && e.IsDel == false).FirstOrDefault();
                    if (couponModel != null)
                    {
                        UserCoupon userCoupon = new UserCoupon()
                        {
                            CouponId = couponModel.Id,
                            UserId = userModel.Id,
                            HighestDeduction = couponModel.DiscountedPrice,
                            ValidityPeriod = DateTime.Now.AddDays(couponModel.EffectiveLong)
                        };

                        _userCouponRepository.Add(userCoupon);
                    }
                }
                else
                {
                    return JsonError("未找到对应邀请码的用户");
                }

                return JsonOk("添加成功");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }            
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult ModifyUser(UserInfo user)
        {
            var oldUser = _userInfoRepository.GetSingle(user.Id);
            oldUser.Img = user.Img;
            oldUser.Old = user.Old;
            oldUser.Sex = user.Sex;
            oldUser.UpdateTime = DateTime.Now;
            oldUser.UserName = user.UserName;

            _userInfoRepository.Update(oldUser);

            return JsonOk("修改成功");
        }
    }
}