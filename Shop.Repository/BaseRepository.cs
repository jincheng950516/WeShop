using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;
using Shop.Model;
using System.Data.Entity;

namespace Shop.Repository
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //实例化上下文对象 从工厂中获取对象
        private readonly WeShop ws = DbContextFactory.GenInstance();
        //现在还在dal层，只能操作底层数据
       // 声明一个接口类型的变量
         //IBaseRepository<TEntity> _ibaseRepository;
        private readonly DbSet<TEntity> dbset;
        public BaseRepository()
        {
            dbset = ws.Set<TEntity>();//构造一个实体集
        }
        //public BaseRepository(IBaseRepository<TEntity> ibaseRepository)
        //{
        //    this._ibaseRepository = ibaseRepository;
        //    //  ws.Set<TEntity>();
        //}
        public void Delete(TEntity tEntity)
        {
            //删除指定的实体，先从集合中查找到该实体，然后在删除
            dbset.Attach(tEntity);
            dbset.Remove(tEntity);
        }

        public void Insert(TEntity tEntity)
        {
            dbset.Add(tEntity);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> wherelambda)
        {
            return dbset.Where(wherelambda);
        }

        public IEnumerable<TEntity> QueryEntitiesByPage<Ttype>(int pageindex, int pagesize, bool isAsc, Expression<Func<TEntity, Ttype>> OrderByLambda, Expression<Func<TEntity, bool>> wherelambda)
        {
            var result = dbset.Where(wherelambda);
            result = isAsc ? result.OrderBy(OrderByLambda) : result.OrderByDescending(OrderByLambda);
            result = result.Skip((pageindex - 1) * pagesize).Take(pagesize);
            return result.ToList();
        }

        public TEntity QueryEntity(Func<TEntity, bool> wherelambda)
        {
            return dbset.FirstOrDefault(wherelambda);
        }

        public bool SaveChanges()
        {
            return ws.SaveChanges() > 0;
        }

        public void Update(TEntity tEntity)
        {
            // throw new NotImplementedException();
            //先查找要更新额实体，然后在覆盖原有的
            dbset.Attach(tEntity);
            ws.Entry(tEntity).State = EntityState.Modified;
        }
    }
}
