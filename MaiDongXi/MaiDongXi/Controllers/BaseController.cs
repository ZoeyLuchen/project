using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MaiDongXi.Controllers
{
    [UserAuthorize]
    public class BaseController : Controller
    {
        public BaseController()
        {
            try
            {
                CurrentUserInfo = UserHelper.CurrentUserInfo;
            }
            catch
            {
                Response.Redirect("/Login/Index");
            }
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