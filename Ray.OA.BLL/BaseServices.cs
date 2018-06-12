using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IBaseDal.cs;
using Spring.Context;
using Spring.Context.Support;

namespace Ray.OA.BLL
{
    abstract public class BaseServices<TModel> where TModel: class, new()
    {  
        #region Spring.Net依赖注入DbContextEnity 和 Dal, 这里自动用的
        public DbContext DbContextEnity{get; set;}
        public IBaseDal<TModel> CurrentDal { get; set; }
        #endregion

        #region Function

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="whereLmbda">查询的条件Lmbda表达式</param>
        /// <returns></returns>
        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> whereLmbda)
        {
            return CurrentDal.Get(whereLmbda);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">添加的实体</param>
        public void Add(TModel model)
        {
            CurrentDal.Add(model);
            DbContextEnity.SaveChanges();
        }

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(TModel model)
        {
            try
            {
                CurrentDal.Update(model);
                DbContextEnity.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="WhereLambda">删除条件的lambda的表达式</param>
        /// <returns>符合此lambda的集合</returns>
        public int Delete(Expression<Func<TModel, bool>> WhereLambda)
        {
            //DbContextEnity.SaveChanges();
            int Count = CurrentDal.Delete(WhereLambda);
            DbContextEnity.SaveChanges();
            return Count;
        }

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
            return CurrentDal.GetPage(PageSize, PageIndex, out Total, WhereLambda, OrderByLambda, IsAsc);
        }


        #endregion
    }
}
