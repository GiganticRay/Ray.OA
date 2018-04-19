using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.IDAL;
using Ray.OA.EFDAL;

namespace Ray.OA.DalFactory
{
    //这样做就做到了：一次操作由一个会话完成、减少了对数据库的操作次数、更加灵活
    public class DbSession
    {
        #region 简单工厂或抽象工厂部分

        public IOAUserInfoDal GetUserInfoDal
        {
            get { return StaticFactory.GetOAUserInfoDal(); }
        }

        public IOAOrderInfoDal GetOrderInfoDal
        {
            get { return StaticFactory.GetOAOrderInfoDal(); }
        }

        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }

        #endregion
    }
}
