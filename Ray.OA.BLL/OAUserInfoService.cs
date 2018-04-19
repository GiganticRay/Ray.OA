using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using Ray.OA.DalFactory;
using Ray.OA.EFDAL;
using Ray.OA.IDAL;
using Ray.OA.Model;

namespace Ray.OA.BLL
{
    //模块内高内聚、模块间低耦合

    //跨数据库、有Mysql、Sqlserver等等、数据库访问驱动层发生变化
    public class OAUserInfoService : BaseService<OAUserInfo>
    {
        #region 如何不继承Baseservice实现CRUD的方法
        //DbSession dbSession = new DbSession();
        //public OAUserInfo Add(OAUserInfo userinfo)
        //{

        //    //return StaticFactory.GetOAUserInfoDal().Add(userinfo);
        //    OAUserInfo tmp = dbSession.GetUserInfoDal.Add(userinfo);
        //    dbSession.SaveChanges();
        //    return tmp;
        //}

        //public IQueryable<OAUserInfo> Get(Expression<Func<OAUserInfo, bool>> WhereLambda)
        //{
        //    return StaticFactory.GetOAUserInfoDal().Get(WhereLambda);
        //}

        //public void Delete(Expression<Func<OAUserInfo, bool>> WhereLambda)
        //{
        //    StaticFactory.GetOAUserInfoDal().Delete(WhereLambda);
        //}
        #endregion

        

        public override void SetCurrentDal()
        {
            CurrentDal = dbSession.GetUserInfoDal;
        }
    }
}
