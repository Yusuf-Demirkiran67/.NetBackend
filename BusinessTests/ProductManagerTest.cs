using Business.Concrete.Managers;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BusinessTests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
