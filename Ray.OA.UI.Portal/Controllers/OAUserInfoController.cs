using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ray.OA.BLL;
using Ray.OA.Model;

namespace Ray.OA.UI.Portal.Controllers
{
    public class OAUserInfoController : Controller
    {
        //
        // GET: /OAUserInfo/
        OAUserInfoService userinfoService = new OAUserInfoService();
        public ActionResult CreateResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateResult(OAUserInfo oaUserinfo)
        {
            if (ModelState.IsValid)
            {
                userinfoService.Add(oaUserinfo);
            }
            return Content("添加成功");
        }

    }
}
