﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_AD_Shop.Core.Contracts;
using My_AD_Shop.Core.Models;
using My_AD_Shop.Core.ViewModels;
using My_AD_Shop.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace My_AD_Shop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCatgeoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext, productCatgeoryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());

        }
    }
}
