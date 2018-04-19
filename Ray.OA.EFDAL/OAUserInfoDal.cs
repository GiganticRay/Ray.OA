using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ray.OA.IDAL;
using Ray.OA.Model;

namespace Ray.OA.EFDAL
{

    [TestFixture]
    //继承BaseDal方法、实现了IOAOrderInfoDal
    public class OAUserInfoDal: BaseDal<OAUserInfo>, IOAUserInfoDal
    {
        public OAUserInfoDal(){ }
        //private DataModelContainer DbContext { get; set; }

        

        #region UserInfo自己的Crud + NuitTest

        

        

        //#region 查询
        ///// <summary>
        ///// 获取UsersQueryable集合
        ///// </summary>
        ///// <returns>匹配的Lambda表达式</returns>
        //public IQueryable<OAUserInfo> GetUsers(Expression<Func<OAUserInfo, bool>> WhereLambda)
        //{
        //    if (DbContext == null)
        //    {
        //        DbContext = new DataModelContainer();
        //    }

        //    return DbContext.OAUserInfo.Where(WhereLambda).AsQueryable<OAUserInfo>();
        //}
        //#endregion

        //#region 分页查询

        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <typeparam name="T">根据...排序的字段的Type</typeparam>
        ///// <param name="PageSize">每页的容量</param>
        ///// <param name="PageIndex">当前页码</param>
        ///// <param name="Total">页的总量</param>
        ///// <param name="WhereLambda">查询的Lambda条件</param>
        ///// <param name="OrderByLambda">排序的Lambda条件</param>
        ///// <param name="IsAsc">是否升序</param>
        ///// <returns></returns>
        //public IQueryable<OAUserInfo> GetPageUseres<T>(int PageSize, int PageIndex, out int Total,
        //    Expression<Func<OAUserInfo, bool>> WhereLambda, Expression<Func<OAUserInfo, T>> OrderByLambda, bool IsAsc)
        //{
            
        //    if (DbContext == null)
        //    {
        //        DbContext = new DataModelContainer();
        //    }

        //    IQueryable<OAUserInfo> OAUserInfoQuery = null;
        //    //传出总页码
        //    Total = DbContext.OAUserInfo.Where(WhereLambda).Count();

        //    if (IsAsc == true)
        //    {
        //        OAUserInfoQuery = DbContext.OAUserInfo.Where(WhereLambda)
        //            .OrderBy<OAUserInfo, T>(OrderByLambda)
        //            .Skip((PageIndex - 1) * PageSize)
        //            .Take(PageSize).AsQueryable();
        //    }
        //    else
        //    {
        //        OAUserInfoQuery = DbContext.OAUserInfo.Where(WhereLambda)
        //            .OrderByDescending<OAUserInfo, T>(OrderByLambda)
        //            .Skip((PageIndex - 1) * PageSize)
        //            .Take(PageSize).AsQueryable();
        //    }


        //    return OAUserInfoQuery;
        //}

        //#endregion

        //#region 增加

        ///// <summary>
        ///// 插入
        ///// </summary>
        ///// <param name="userinfo">要插入的UserInfo</param>
        ///// <returns>返回插入的UserInfo</returns>
        //public OAUserInfo Add(OAUserInfo userinfo)
        //{
        //    if (DbContext == null)
        //    {
        //        DbContext = new DataModelContainer();
        //    }

        //    DbContext.OAUserInfo.Attach(userinfo);
        //    DbContext.Entry(userinfo).State = EntityState.Added;
        //    DbContext.SaveChanges();
        //    return userinfo;
        //}
        //#endregion

        //#region 删除

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="WhereLambda">删除条件的lambda的表达式</param>
        ///// <returns>符合此lambda的集合</returns>
        //public int Delete(Expression<Func<OAUserInfo, bool>> WhereLambda)
        //{
        //    if (DbContext == null)
        //    {
        //        DbContext = new DataModelContainer();
        //    }
        //    //获取符合此lambda的集合
        //    IQueryable<OAUserInfo> OAUserinfoQuery = DbContext.OAUserInfo.Where(WhereLambda).AsQueryable();
        //    int DeleteCount = OAUserinfoQuery.Count();
        //    foreach (var VARIABLE in OAUserinfoQuery)
        //    {
        //        DbContext.OAUserInfo.Attach(VARIABLE);
        //        DbContext.Entry(VARIABLE).State = EntityState.Deleted;
        //    }
        //    DbContext.SaveChanges();
        //    return DeleteCount;
        //}
        

        //#endregion

        //#region 修改

        //public bool Update(OAUserInfo userInfo)
        //{
        //    if (DbContext == null)
        //    {
        //        DbContext = new DataModelContainer();
        //    }
        //    DbContext.Entry(userInfo).State = EntityState.Modified;
        //    return DbContext.SaveChanges() > 0;
        //}

        //#endregion



        //#region NunitTest
        //[Test]
        //public void TestGetUser()
        //{
        //    IQueryable<OAUserInfo> testtmp = GetUsers(user => user.Id == 1);
        //    foreach (var VARIABLE in testtmp)
        //    {
        //        Console.WriteLine(VARIABLE.Id + VARIABLE.UName);
        //    }
        //}

        //[Test]
        //public void TestAddUser()
        //{
        //    OAUserInfo userinfo = new OAUserInfo();
        //    userinfo.UName = "Ray1";
        //    Add(userinfo);
        //    Console.WriteLine("插入成功");
        //}

        //[Test]
        //public void TestDeleteUser()
        //{
        //    int DeleteCount = Delete(user => user.UName == "Ray1");
        //    Console.WriteLine("成功删除 {0} 条数据", DeleteCount);
        //}

        //[Test]
        //public void TestUpdate()
        //{
        //    OAUserInfo userinfo = new OAUserInfo();
        //    userinfo.Id = 1;
        //    userinfo.UName = "BigRay";
        //    var IsSuccessfully = Update(userinfo);
        //    Console.WriteLine(IsSuccessfully);
        //}
        //#endregion


        #endregion
    }
}
