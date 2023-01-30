using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.AutoFac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            // eğer birisi constructor'da IProductService isterse ona manageri ver
            builder.RegisterType<EfProductDal>().As<IProductDal>();


            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            // eğer birisi constructor'da IProductService isterse ona manageri ver
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            // eğer birisi constructor'da IProductService isterse ona manageri ver
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}
