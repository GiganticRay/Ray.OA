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
        public void GetTest()
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
            
            Console.WriteLine("\r\n删除{0}数据成功", userinfoservice.Delete(user => user.UName == "Leichao1"));
        }
    }
}
