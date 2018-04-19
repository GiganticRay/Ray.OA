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
    public class StaticFactory
    {
        //从配置文件获取引用程序集的名称
        public static string AssemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];

        //简单工厂转抽象工厂
        public static IOAUserInfoDal GetOAUserInfoDal()
        {
            //根据程序集反射返回对象实例
            //return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".OAUserInfoDal") as  IOAUserInfoDal;
            return new OAUserInfoDal();
        }
    }
}
