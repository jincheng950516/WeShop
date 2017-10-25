using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using System.Runtime.Remoting.Messaging;

namespace Shop.Repository
{
    /// <summary>
    ///  工厂类  专门用来实例化上下文对象
    /// </summary>
    public class DbContextFactory
    {

        public static WeShop GenInstance()
        {
            WeShop wshop = CallContext.GetData("DbContext") as WeShop;
            if (wshop == null)
            {
                wshop = new WeShop();
                CallContext.SetData("DbContext", wshop);//如果通道中没有该参数，则向通道中添加该参数
                return wshop;
            }
            return wshop;
        }


    }
}
