using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.Model;
using System.Data.Entity;

namespace Ray.OA.EFDAL
{
    /// <summary>
    /// 封装所有Dal的公共crud方法 
    /// </summary>
    public class BaseDal<TModel> where TModel:class , new ()//约束条件： TModel必须是一个类， 而且默认构造函数
    {
        //但是这样写实体的话解耦合度不高 ：例如如果换了数据库访问驱动、那么BLL层也要做相应的更改、所以这里采用接口的实现
        static private DbContext DbContextEnity
        {
            get { return DbContextFactory.GetCurrentDbContext(); }
        }

        #region 查询
        /// <summary>
        /// 获取UsersQueryable集合
        /// </summary>
        /// <returns>匹配的Lambda表达式</returns>
        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> WhereLambda)
        {
            return DbContextEnity.Set<TModel>().Where(WhereLambda).AsQueryable<TModel>();
        }
        #endregion

        #region 分页查询

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">根据...排序的字段的Type</typeparam>
        /// <param name="PageSize">每页的容量</param>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="Total">页的总量</param>
        /// <param name="WhereLambda">查询的Lambda条件</param>
        /// <param name="OrderByLambda">排序的Lambda条件</param>
        /// <param name="IsAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<TModel> GetPage<T>(int PageSize, int PageIndex, out int Total,
            Expression<Func<TModel, bool>> WhereLambda, Expression<Func<TModel, T>> OrderByLambda, bool IsAsc)
        {
            IQueryable<TModel> TModelQuery = null;
            //传出总页码
            Total = DbContextEnity.Set<TModel>().Where(WhereLambda).Count();

            if (IsAsc == true)
            {
                TModelQuery = DbContextEnity.Set<TModel>().Where(WhereLambda)
                    .OrderBy<TModel, T>(OrderByLambda)
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize).AsQueryable();
            }
            else
            {
                TModelQuery = DbContextEnity.Set<TModel>().Where(WhereLambda)
                    .OrderByDescending<TModel, T>(OrderByLambda)
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize).AsQueryable();
            }


            return TModelQuery;
        }

        #endregion

        #region 增加

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="Enity">要插入的UserInfo</param>
        /// <returns>返回插入的UserInfo</returns>
        public TModel Add(TModel Enity)
        {
            DbContextEnity.Entry(Enity).State = EntityState.Added;
            DbContextEnity.SaveChanges();
            return Enity;
        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="WhereLambda">删除条件的lambda的表达式</param>
        /// <returns>符合此lambda的集合</returns>
        public int Delete(Expression<Func<TModel, bool>> WhereLambda)
        {
            //获取符合此lambda的集合
            IQueryable<TModel> TModelQuery = DbContextEnity.Set<TModel>().Where(WhereLambda).AsQueryable();
            int DeleteCount = TModelQuery.Count();
            foreach (var VARIABLE in TModelQuery)
            {
                DbContextEnity.Entry(VARIABLE).State = EntityState.Deleted;
            }
            DbContextEnity.SaveChanges();
            return DeleteCount;
        }


        #endregion

        #region 修改

        public bool Update(TModel Enity)
        {
            DbContextEnity.Entry(Enity).State = EntityState.Modified;
            return DbContextEnity.SaveChanges() > 0;
        }

        #endregion


    }
}
