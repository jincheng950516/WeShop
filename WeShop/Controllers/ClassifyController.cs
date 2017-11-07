using Shop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
namespace WeShop.Controllers
{
    public class ClassifyController : Controller
    {
        public ISortService SortService { get; set; }
        public IProSortService ProSortService { get; set; }
        // GET: Classify
        public ActionResult Index()
        {
            List<Sort> SortResult = SortService.GetEntities(x => true).ToList();
            ViewBag.Sort = SortResult.ToList();

            //var SortResult = SortService.GetEntities(x => true).ToList();
            //ViewBag.Sort = SortResult;


            //var ProSortResult = ProSortService.GetEntities(x => true).OrderByDescending(x => x.SortCode).Take(2);
            //ViewBag.ProSort = ProSortResult.ToList();

            //var ProSortResult = ProSortService.GetEntities(x => x.SortCode == SortResult[0].Code).ToList();
            //ViewBag.ProSort = ProSortResult;

            var s = ProSortService.GetEntities(x => x.SortCode == SortResult[0].Code);
            ViewBag.ProSort = s;
            return View();
        }
        public ActionResult ProSortdata()
        {
            string id = Request["id"];
            List<ProSort> s = ProSortService.GetEntities(a => a.SortCode == id).ToList();
            string shtml = "";
            foreach(ProSort item in s )
            {
                //shtml += @"<li>
                //            <a class='imga' href='#'><img src='~/images/'" + item.Pimg + @"''></a>
                //              <a class='txta' href='#'>
                //              <span>" + item.Pname + @"</span>
                //             <i>" + item.Pcontent + @"</i>
                //             </a>
                //            </li>";
                shtml += "<li>" +
                    "<a class='imga' href='/List/Index'><img src='/images/" + @item.Pimg + "'</a>" +
                    "  <a class='txta' href='/List/Index'>" +
                    " <span>" + @item.Pname + "</span>" +
                    "  <i>" + @item.Pcontent + "</i>" +
                    "</a>" +
                    "</li>";
            }
            return Content(shtml);
        }
    }
}