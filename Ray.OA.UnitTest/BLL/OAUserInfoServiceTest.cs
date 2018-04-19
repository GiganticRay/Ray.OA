using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ray.OA.BLL;
using Ray.OA.Model;

namespace Ray.OA.UnitTest.BLL
{
    [TestClass]
    public class OAUserInfoServiceTest
    {
        [TestMethod]
        public void AddTest()
        {
            OAUserInfoService userinfoservice = new OAUserInfoService();
            OAUserInfo userinfoEnity = new OAUserInfo();;
            userinfoEnity.UName = "Leichao1";
            OAUserInfo userinfo = userinfoservice.Add(userinfoEnity);
            Console.WriteLine("插入测试成功");
        }

        [TestMethod]
        public void SearchTest()
        {
            OAUserInfoService userinfoservice = new OAUserInfoService();
            IQueryable<OAUserInfo> userinfoQuery = userinfoservice.Get(a => a.Id > 0);
            Console.WriteLine("获取的数据有：\r\n");
            foreach (var tmp in userinfoQuery)
            {
                Console.WriteLine(tmp.Id + " " + tmp.UName);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            OAUserInfoService userinfoservice = new OAUserInfoService();
            userinfoservice.Delete(user => user.UName=="Leichao");
            Console.WriteLine("\r\n删除数据成功");
        }
    }
}
