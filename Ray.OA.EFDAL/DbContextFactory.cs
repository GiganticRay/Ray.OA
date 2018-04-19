using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.Model;

namespace Ray.OA.EFDAL
{
    static class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //一个请求共用一个实例
            return new DataModelContainer();
        }
    }
}
