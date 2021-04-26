using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Postsharp;
using Core.DataAccess;
using Core.Aspects.Postsharp.ValidationAspect;
using Core.Aspects.Postsharp.TransactionAspect;

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
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
        
           return _productDal.Update(product);
        }
    }
}
