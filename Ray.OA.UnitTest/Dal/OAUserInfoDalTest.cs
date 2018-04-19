using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ray.OA.EFDAL;
using Ray.OA.Model;

namespace Ray.OA.UnitTest.Dal
{
    [TestClass]
    public class OAUserInfoDalTest
    {
        OAUserInfoDal testDal = new OAUserInfoDal();

        [TestMethod]
        public void Get()
        {
            IQueryable<OAUserInfo> testtmp = testDal.Get(user => user.Id == 1);
            foreach (var VARIABLE in testtmp)
            {
                Console.WriteLine(VARIABLE.Id + VARIABLE.UName);
            }
        }

        [TestMethod]
        public void GetPage()
        {
            int TotalPage;
            IQueryable<OAUserInfo> testquery = testDal.GetPage(3, 1, out TotalPage, user => user.Id > 0, user => user.UName, true);
            Console.WriteLine("总共有{0}条数据", TotalPage);
            foreach (var tmp in testquery)
            {
                Console.WriteLine(tmp.Id + " " + tmp.UName);
            }
        }
    }
}
