﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Postsharp;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public Product Update(Product product)
        {
        
           return _productDal.Update(product);
        }
    }
}
