using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ray.OA.Dal;
using Ray.OA.Model;

namespace UnitTestProject
{
    [TestClass]
    public class OAUserInfoDalTest
    {
        [TestMethod]
        public void Get()
        {
            OAUserInfoDal oaUserInfoDal = new OAUserInfoDal();
            IQueryable<OAUserInfo> IQueryable = oaUserInfoDal.Get(a => a.Id >= 0);
            foreach (OAUserInfo item in IQueryable)
            {
                Console.WriteLine(item.Id + ", " + item.UName);
            }
        }
    }
}
