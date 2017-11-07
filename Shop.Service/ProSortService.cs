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
    public class ProSortService : BaseService<ProSort>, IProSortService
    {
        public ProSortService(IBaseRepository<ProSort> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}
