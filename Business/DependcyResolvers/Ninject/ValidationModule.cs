using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependcyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
        }
    }
}
