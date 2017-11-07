using System;
using Shop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeShop.Controllers
{
    public class ListController : Controller
    {
        public IProductService ProductService { get; set; }
        // GET: List
        public ActionResult Index()
        {
            //产品查询
            var Productresult = ProductService.GetEntities(x => true)/*.OrderByDescending(x => x.Time).Take(2)*/;
            ViewBag.Product = Productresult.ToList();
            return View();
        }
    }
}