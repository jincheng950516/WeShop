using System;
using System.Web.Mvc;
using System.Configuration;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace WeShop.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth 生成授权页面   ---同意授权
        //1:方法中需要AppId Appsecret
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://wx.zjc916.xin";
        public ActionResult Index(string returnUrl)
        {
            //微信中需要使用的地址都是外网地址  域名/returnUrl
            //1：构造带有域名的回调Url 地址需要在函数中带有 $表示变量的占位符
            string callBackUrl = $"http://wx.zjc916.xin{Url.Action("CallBack", new { returnUrl })}";
            string state = "wx" + DateTime.Now.Millisecond;
            //保存状态参数
            Session["state"] = state;
            string oauthorurl = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
            //跳转到授权页面
            return Redirect(oauthorurl);
        }
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <returns></returns>
        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //注意:前提是先要判断用户输入进来的数据state是否满足
            if (Session["state"]?.ToString() != state)
            {
                Session["State"] = null;
                return Content("非安全方式登陆，登陆失败，请重新进入");

            }
            //把session中的数据清理
            Session["state"] = null;

            //判断用户返回的code
            if (string.IsNullOrEmpty(code))
            {
                return Content("未点击商城网址");
            }
            //以token换取accesstoken
            var accessToken = OAuthApi.GetAccessToken(appID, appsecret, code);

            if (accessToken.errcode != ReturnCode.请求成功)
            {
                //需要重新定位到授权页面
                return Content($"错误消息:{accessToken.errmsg}");
            }
            Session["authonAccessToken"] = accessToken;
            //以token 和oppenid来换取用户消息
            try
            {
                OAuthUserInfo usrinfo = OAuthApi.GetUserInfo(accessToken.access_token, accessToken.openid);
                Session["userInfo"] = usrinfo;
                return Redirect(returnUrl);
            }
            catch (Exception)
            {
                //如果是没有获取到用户的信息,则需要进入到授权页面
                var callBackUrl = $"http://wx.minwebsite.xin{Url.Action("Callback", new { returnUrl })}";
                // 随机数，用于加强回调请求的安全，避免被恶意请求，类似验证码
                state = "wx" + DateTime.Now.Millisecond;
                Session["State"] = state;


                var url = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
                return Redirect(url);

            }

        }
        /// <summary>
        /// js-sdk 注入接口配置
        /// </summary>
        /// <returns></returns>
        public ActionResult JsSdkConfig()
        {
            //构造url地址，注意是包含域名的
            string url = $"{Domin}{Request.RawUrl}";
            JsSdkUiPackage jssdkuipackage = JSSDKHelper.GetJsSdkUiPackage(appID, appsecret, url);
            return PartialView(jssdkuipackage);
        }
    }
}