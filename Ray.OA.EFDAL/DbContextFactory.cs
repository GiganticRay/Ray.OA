using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.Model;

namespace Ray.OA.EFDAL
{
    public static class DbContextFactory
    {
        public static DbContext MyDataModelContainer { get; set; }
        public static DbContext GetCurrentDbContext()
        {
            //一个请求共用一个实例
            if (MyDataModelContainer == null)
            {
                MyDataModelContainer = new DataModelContainer();
            }

            return MyDataModelContainer;
        }
    }
}
