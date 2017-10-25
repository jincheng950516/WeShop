using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace WeShop.App_Start
{
    public class AutotacConfig
    {
        public static void autoDepence()
        {
            //先实例化一个构造器
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var iRepository = Assembly.Load("Shop.IRepository");//IDAL
            var iService = Assembly.Load("Shop.IService");//IBLL

            var repository = Assembly.Load("Shop.Repository");//DAL
            var service = Assembly.Load("Shop.Service");//BLL

            builder.RegisterAssemblyTypes(iRepository, repository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //实例化一个容器
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        //internal static void RegisterDependency()
        //{
        //    //throw new NotImplementedException();
        //}
    }
}