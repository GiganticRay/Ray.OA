using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.Model;
using Spring.Context;
using Spring.Context.Support;
using System.Data;

namespace Ray.OA.Dal
{
    public class BaseDal<TModel> where TModel: class, new()
    {

        #region Spring.Net依赖注入DbContextEnity

        static public IApplicationContext ctx = ContextRegistry.GetContext();
        static private DbContext DbContextEnity
        {
            get { return (DbContext)ctx.GetObject("DbContextEnity"); }
        }

        #endregion


        #region 查询
        /// <summary>
        /// 获取TModel集合
        /// </summary>
        /// <param name="WhereLambda">查询的Lambda语句</param>
        /// <returns>查询的结果集合</returns>
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
            return DeleteCount;
        }


        #endregion

        #region 修改

        public bool Update(TModel Enity)
        {
            DbContextEnity.Entry(Enity).State = EntityState.Modified;
            return true;
        }

        #endregion
    }
}
