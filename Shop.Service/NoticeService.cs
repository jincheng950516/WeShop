using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;
using Shop.IService;
using Shop.Model;
namespace Shop.Service
{
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}
