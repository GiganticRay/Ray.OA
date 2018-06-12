using System.Web;
using System.Web.Mvc;
using RAY.OA.Models;

namespace RAY.OA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //添加自己的异常类
            filters.Add(new MyExceptionFilterAttribute());

            //ActionFilter  在Action执行前后执行的C#代码
            //ResultFilter  
            //异常过滤器
        }
    }
}