using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_AD_Shop.Core.Contracts;
using My_AD_Shop.Core.Models;
using My_AD_Shop.Services;
using My_AD_Shop.WebUI.Tests.Controllers.Mocks;
using My_AD_Shop.WebUI.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_AD_Shop.WebUI.Tests.Controllers
{
    public class BasketControllerTests
    {
        private object controller;

        [TestMethod]
        public void CanAddBasketItem()
        {
            //setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            var httpContext = new MockHttpContext();


            IBasketService basketService = new BasketService(products, baskets);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            //Act
            //basketService.AddToBasket(httpContext, "1");
            controller.AddToBasket("1");

            Basket basket = baskets.Collection().FirstOrDefault();


            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }

    }
}
