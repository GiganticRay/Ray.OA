using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAY.OA.Models
{
    public class BaseController : Controller
    {
        //在当前的控制器里面所有的方法执行之前都要执行此代码
        public bool IsCheck { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheck)
            {
                //校验用户是否已登陆
                if (filterContext.HttpContext.Session["LoginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("../Login/Login");
                }
            }

        }

    }
}