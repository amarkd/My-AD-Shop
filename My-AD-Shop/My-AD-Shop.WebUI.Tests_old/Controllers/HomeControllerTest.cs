using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_AD_Shop.Core.Contracts;
using My_AD_Shop.Core.Models;
using My_AD_Shop.Core.ViewModels;
using My_AD_Shop.WebUI;
using My_AD_Shop.WebUI.Controllers;
using My_AD_Shop.WebUI.Tests.Mocks;

namespace My_AD_Shop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new MockContext<Product>();
            IRepository<ProductCategory> productCatgeoryContext = new MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext, productCatgeoryContext);

            productContext.Insert(new Product());

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());

        }
    }
}
