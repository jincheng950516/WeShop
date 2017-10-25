using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IService
{
    public interface IBaseService<TEntity> where TEntity:class,new()
    {
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        bool Modify(TEntity entity);
       
        //查询单个
        TEntity GetEntity(Func<TEntity, bool> wherelambda);
        //查询多个
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> wherelambda);
        //查询分页
        IEnumerable<TEntity> GetModelsByPage<Ttype>(int pageindex, int pagesize, bool isAsc,
        Expression<Func<TEntity, Ttype>> OrderByLambda, Expression<Func<TEntity, bool>> wherelambda);
    }
}
