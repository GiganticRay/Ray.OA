using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //从配置文件中读取log4net的配置、然后进行一个初始化的工作
            log4net.Config.XmlConfigurator.Configure();

            //写日志
            log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");//获取一个日志记录器
            log.Info(DateTime.Now.ToString() + ": login success");//写入一条新 log
            
            Console.ReadKey(true);
        }
    }
}
