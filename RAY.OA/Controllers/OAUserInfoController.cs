using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ray.OA.BLL;
using RAY.OA.Common;
using Ray.OA.Model;
using RAY.OA.Models;

namespace RAY.OA.Controllers
{
    public class OAUserInfoController : BaseController
    {
        public OAUserInfoController ()
        {
            IsCheck = true;
        }
        //
        // GET: /OAUserInfo/
        public OAUserInfoService oaUserInfoService;
        public ActionResult Index()
        {
            ViewData.Model = oaUserInfoService.Get(a => a.Id >= 0);
            //throw new Exception("123");

            return View();
        }

    }

    public class LoginForm
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string VCode { get; set; }
    }
}