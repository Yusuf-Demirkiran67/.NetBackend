using Business.Abstract;
using Business.Concrete.Managers;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.NHihabernate;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependcyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
