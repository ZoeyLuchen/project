﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SexShop.Common;
using SexShop.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace SexShop.Controllers
{
    //[UserAuthorize]
    public class BaseController : Controller
    {
        public CurrentUserInfo CurrentUser;
        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            else
            {
                CurrentUser = ByteConvertHelper.Bytes2Object<CurrentUserInfo>(result);
            }
            base.OnActionExecuting(filterContext);
        }

        public IActionResult JsonOk<T>(T data,string message ="")
        {
            var result = new ReturnResult<T>();
            result.Message = message == "" ? "操作成功" : message;
            result.Code = 200;
            result.Data = data;

            return Json(result);
        }

        public IActionResult JsonError(string message = "")
        {
            var result = new ReturnResult<string>();
            result.Message = message == "" ? "操作失败" : message;
            result.Code = 500;
            result.Data = "";

            return Json(result);
        }
    }

    public class ReturnResult<T>
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}