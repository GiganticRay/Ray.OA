using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ray.OA.BLL;
using RAY.OA.Common;
using Ray.OA.Model;

namespace RAY.OA.Controllers
{
    public class LoginController : Controller
    {

        //
        // GET: /Login/
        public OAUserInfoService oaUserInfoService;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm loginForm)
        {
            if (loginForm.VCode.ToUpper() != Session["VCode"].ToString())
            {
                return Content("验证码错误");
            }
            IQueryable<OAUserInfo> tmp = oaUserInfoService.Get(a => a.UName == loginForm.UserId);

            if (tmp.Count() != 0)
            {
                Session["LoginUser"] = tmp.First();
                return Content("登陆成功");
            }
            else
            {
                return Content("给老子密码都不对");
            }
        }

        //验证码
        public ActionResult VertifyCodeImg()
        {
            Common.ProduceVertifuCode VertifuCodeProduct = new ProduceVertifuCode();
            string vertifycode = VertifuCodeProduct.CreateRandomCode(4);
            Session["VCode"] = vertifycode;
            Stream a = VertifuCodeProduct.CreateImage(vertifycode);
            a.Position = 0;
            return File(a, @"image/jpeg");
        }

    }
}
