using Shop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeShop.Controllers
{
    /// <summary>
    /// 商城首页
    /// </summary>
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }
        public IProductService ProductService { get; set; }
        // GET: Home
        /// <summary>
        /// 首页数据查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //查询Banner,从数据库中查询
            //ui层，不能直接实例化BLL，应该利用IBLL
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();
            var Productresult = ProductService.GetEntities(x => true)/*.OrderByDescending(x => x.Time).Take(3)*/;
            ViewBag.Product = Productresult.ToList();
            return View();
        }
        //搜索
        public ActionResult Search()
        {
            return PartialView();
        }
    }
}