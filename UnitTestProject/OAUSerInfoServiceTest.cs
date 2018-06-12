using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ray.OA.BLL;
using Ray.OA.Dal;
using Ray.OA.Model;

namespace UnitTestProject
{
    [TestClass]
    public class OAUSerInfoServiceTest
    {

        public OAUserInfoService oaUserInfoService = new OAUserInfoService();
        [TestMethod]
        public void Get()
        {
            
            IQueryable<OAUserInfo> IQueryable = oaUserInfoService.Get(a => a.Id >= 0);
            foreach (OAUserInfo item in IQueryable)
            {
                Console.WriteLine(item.Id + ", " + item.UName);
            }
        }

        [TestMethod]
        public void Add()
        {
            OAUserInfo userinfo = new OAUserInfo();
            userinfo.UName = "lkl1";
            oaUserInfoService.Add(userinfo);
            //添加成功说明了sington是单次请求下唯一
            Console.WriteLine("添加成功");
        }
    }
}
