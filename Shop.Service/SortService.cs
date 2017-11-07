using Shop.IService;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;

namespace Shop.Service
{
    public class SortService : BaseService<Sort>, ISortService
    {
        public SortService(IBaseRepository<Sort> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}
