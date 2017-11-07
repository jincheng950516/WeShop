using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeicharDemo.Fiters;


namespace WeShop.Controllers
{
    public class FamilyController : Controller
    {
        // GET: Family
        public ActionResult Index()
        {
            var userInfo = Session["userInfo"] as OAuthUserInfo;
            return View(userInfo);
           
        }
    }
}