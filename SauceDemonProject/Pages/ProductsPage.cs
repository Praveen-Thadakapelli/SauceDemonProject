using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SauceDemonProject.Utilities;

namespace SauceDemonProject.Pages
{
    class ProductsPage
    {
        private IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public IWebElement AppLogo => driver.FindElement(By.XPath("//div[@class='app_logo']"));
        private IWebElement Products => driver.FindElement(By.XPath("//button[text() ='Add to cart'][1]"));

        private IWebElement Cart => driver.FindElement(By.XPath("//div[@id='shopping_cart_container']//a"));

        private IWebElement GetUserName => driver.FindElement(By.XPath("//div[@id='login_credentials']"));
        private IWebElement GetPassword => driver.FindElement(By.XPath("//div[@class='login_password']"));

        public void AddProductToCart()
        {
            Assert.IsTrue(Products.Displayed);
            Helper.ClickAction(Products);
            Console.WriteLine("Product has selected.");
            Assert.IsTrue(Cart.Displayed);
            Helper.ClickAction(Cart);
            Console.WriteLine("Added products to cart");
        }
    }
}
