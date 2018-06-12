using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RAY.OA.Common
{
    public class LogHelper
    {
        //从配置文件中读取log4net的配置、然后进行一个初始化的工作
        public static log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");
        static LogHelper()
        {
            
            //开启线程从队列里面读取错误消息写入日志文件
            ThreadPool.QueueUserWorkItem(o=>
            {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Count != 0)
                        {
                            string errorStr = ExceptionStringQueue.Dequeue();
                            //这里要注意， 要适配将日志写道文件、还是数据库的一个过程、用观察者模式吧
                            log.Info(DateTime.Now.ToString() + errorStr);
                        }
                    }
                }
            });
        }


        //存放错误的静态队列
        public static Queue<string> ExceptionStringQueue = new Queue<string>();

        public static void WriteLog(string ExceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(ExceptionText);
            }
        }
    }
}
