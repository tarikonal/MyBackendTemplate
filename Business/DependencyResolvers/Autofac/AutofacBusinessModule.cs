using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// startup da yazdıklarını buraya taşıyorsun
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();// --> services.AddSingleton<IProductService, ProductManager>();
           builder.RegisterType<EFProductDal>().As<IProductDAL>().SingleInstance();// --> services.AddSingleton<IProductService, ProductManager>();
           builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance(); 
           builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
