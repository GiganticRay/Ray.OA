using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.EFDAL;
using Ray.OA.IDAL;
using  System.Web.Configuration;

namespace Ray.OA.DalFactory
{
    /// <summary>
    /// BLL层调用
    /// </summary>
    public class StaticFactory
    {
        //从配置文件获取引用程序集的名称
        public static string AssemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"].ToString();

        private static IOAUserInfoDal ioauserinfodal { get; set; }
        private static IOAOrderInfoDal ioaorderinfodal { get; set; }

        //简单工厂转抽象工厂
        public static IOAUserInfoDal GetOAUserInfoDal()
        {
            if (ioauserinfodal == null)
            {
                //根据程序集反射返回对象实例
                //return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".OAUserInfoDal") as  IOAUserInfoDal;
                ioauserinfodal = Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".OAUserInfoDal") as IOAUserInfoDal;
            }

            return ioauserinfodal;
        }

        public static IOAOrderInfoDal GetOAOrderInfoDal()
        {
            if (ioauserinfodal == null)
            {
                ioaorderinfodal = Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".OAOrderInfoDal") as IOAOrderInfoDal;
            }

            return ioaorderinfodal;
        }
    }
}
