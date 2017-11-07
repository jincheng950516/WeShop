using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WeicharDemo.Fiters
{
    /// <summary>
    /// 判断用户是否具备访问第三方网站的权限
    /// </summary>
    public class OAuthAttribute : AuthorizeAttribute
    {
        //应该还是用哪个值，来判断用户是否可以直接进入
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["authonAccessToken"] == null)
            {
                //1:获取当前请求的页面
                string returnUrl = filterContext.HttpContext.Request.RawUrl;
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(url.Action("Index", "OAuth", new { returnUrl }));
            }
        }
    }
}