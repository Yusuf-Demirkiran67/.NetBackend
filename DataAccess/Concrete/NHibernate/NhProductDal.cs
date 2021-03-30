using Core.DataAccess.NHibernate;
using Core.DataAccess.NHihabernate;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
        NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session=_nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                join c in session.Query<Category>() on p.CategoryId 
                equals c.CategoryId
                select new ProductDetail
                {
                    ProductId = p.ProductId,
                    CategoryName = c.CategoryName,
                    ProductName = p.ProductName
                    
                };
                return result.ToList();
            }
        }
    }
}
