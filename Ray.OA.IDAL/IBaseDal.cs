using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ray.OA.IDAL
{
    public interface IBaseDal<TModel> where TModel:class, new ()
    {
        //private DataModelContainer DbContext { get; set; }

        #region 查询

        /// <summary>
        /// 获取UsersQueryable集合
        /// </summary>
        /// <returns>匹配的Lambda表达式</returns>
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> WhereLambda);
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
        IQueryable<TModel> GetPage<T>(int PageSize, int PageIndex, out int Total,
            Expression<Func<TModel, bool>> WhereLambda, Expression<Func<TModel, T>> OrderByLambda, bool IsAsc);

        #endregion

        #region 增加

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="Enity">要插入的UserInfo</param>
        /// <returns>返回插入的UserInfo</returns>
        TModel Add(TModel Enity);
        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="WhereLambda">删除条件的lambda的表达式</param>
        /// <returns>符合此lambda的集合</returns>
        int Delete(Expression<Func<TModel, bool>> WhereLambda);


        #endregion

        #region 修改

        bool Update(TModel Enity);

        #endregion
    }
}
