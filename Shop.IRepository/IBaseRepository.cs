using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IRepository
{
    /// <summary>
    /// 因为通用类中的每一个功能都是可以被任何的实体使用，如果参数类型不一致，可以用泛型来解决
    /// 如果有一定的约束条件：where T:class 表示必须是引用类型，new(),表示要有一个无参数的构造函数
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        //接口是用来定义功能的；insert ,delete,update,select
        void Insert(TEntity tEntity);
        void Delete(TEntity tEntity);
        void Update(TEntity tEntity);
        bool SaveChanges();
        //单个实体查询 Func<T,Tresult> f 就是一个内置的委托，而lambda表达式也是一个委托（匿名委托）
        //单个肯定带有条件 where 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wherelambda">就是写lambda的表达式</param>
        TEntity QueryEntity(Func<TEntity, bool> wherelambda);
        //查询多个
        IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> wherelambda);
        //分页 pageindex,pagesize,
        //Expression <Func<TEntity, Ttype>> 和Func<TEntity,bool> wherelambda
         
        IEnumerable<TEntity>QueryEntitiesByPage<Ttype>(int pageindex, int pagesize, bool isAsc,
           Expression<Func<TEntity, Ttype>> OrderByLambda, Expression<Func<TEntity, bool>> wherelambda);

    }
}