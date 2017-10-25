using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IService;
using Shop.IRepository;
namespace Shop.Service
{
    //Bll层，不能直接实例化DAL，应该依赖于IDAL
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //声明一个DAL的对象
        private readonly IBaseRepository<TEntity> _ibaseRepository;
        //写构造函数传参数

        public BaseService(IBaseRepository<TEntity> ibaseRepository)
        {
            _ibaseRepository = ibaseRepository;
        }
        public bool Add(TEntity entity)
        {
            //throw new NotImplementedException();
            _ibaseRepository.Insert(entity);
            return _ibaseRepository.SaveChanges();
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> wherelambda)
        {
            //throw new NotImplementedException();
            return _ibaseRepository.QueryEntities(wherelambda);
        }

        public TEntity GetEntity(Func<TEntity, bool> wherelambda)
        {
            return _ibaseRepository.QueryEntity(wherelambda);
        }

        public IEnumerable<TEntity> GetModelsByPage<Ttype>(int pageindex, int pagesize, bool isAsc, Expression<Func<TEntity, Ttype>> OrderByLambda, Expression<Func<TEntity, bool>> wherelambda)
        {
            return _ibaseRepository.QueryEntitiesByPage(pagesize, pageindex, isAsc, OrderByLambda, wherelambda);
        }

        public bool Modify(TEntity entity)
        {
            _ibaseRepository.Update(entity);
            return _ibaseRepository.SaveChanges();
        }

        public bool Remove(TEntity entity)
        {
            _ibaseRepository.Delete(entity);
            return _ibaseRepository.SaveChanges();
        }


    }
}
