using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaiDongXi.Common
{
    //public class UserAuthorizeAttribute : AuthorizeAttribute
    //{
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        string control = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    //        string action = filterContext.ActionDescriptor.ActionName;

    //        var actionAnonymous = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true) as IEnumerable<AllowAnonymousAttribute>;
    //        var controllerAnonymous = filterContext.Controller.GetType().GetCustomAttributes(typeof(AllowAnonymousAttribute), true) as IEnumerable<AllowAnonymousAttribute>;
    //        if ((actionAnonymous != null && actionAnonymous.Any()) || (controllerAnonymous != null && controllerAnonymous.Any()))
    //        {
    //            return;
    //        } 


    //        var doUserInfo = UserHelper.CurrentUserInfo;
    //        if (doUserInfo == null)
    //        {

    //            if (filterContext.HttpContext.Request.IsAjaxRequest())
    //            {
    //                filterContext.HttpContext.Response.Write("501");
    //                filterContext.HttpContext.Response.End();
    //            }
    //            else
    //            {
    //                filterContext.HttpContext.Response.Write("<script>window.top.location.href='/Login/Index'</script>");
    //                filterContext.HttpContext.Response.End();
    //            }
    //            return;
    //        }

    //        if (!doUserInfo.PermissionList.Any(item => item.Controller.ToLower() == control.ToLower() && item.Action.ToLower() == action.ToLower()))
    //        {
    //            if (!filterContext.HttpContext.Request.IsAjaxRequest())
    //            {
    //                filterContext.Result = new ContentResult { Content = @"抱歉,你不具有当前操作的权限！" };
    //            }
    //        }

    //    }
    //}
}
