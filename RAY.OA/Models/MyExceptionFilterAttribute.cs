using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAY.OA.Common;

namespace RAY.OA.Models
{   
    //继承global.asax.cs下面的过滤器中的 处理错误过滤器
    public class MyExceptionFilterAttribute : HandleErrorAttribute
    {
        //重写OnException方法
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //自己处理
            LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}