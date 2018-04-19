using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ray.OA.BLL;
using Ray.OA.Model;

namespace Ray.OA.UnitTest.BLL
{
    [TestClass]
    public class OAOrderInfoServiceTest
    {
        OAOrderInfoService orderinfoService = new OAOrderInfoService();
        [TestMethod]
        public void AddTest()
        {
            OAOrderInfo orderinfo = new OAOrderInfo();
            orderinfo.Content = "小米2s";
            orderinfo.OAUserInfoId = 27;
            orderinfoService.Add(orderinfo);
            Console.WriteLine("插入Orderinfo成功");
        }
    }
}
