using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SauceDemonProject.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SauceDemonProject.Pages
{
    class CartPage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        private IWebElement CheckOutBtn => driver.FindElement(By.XPath("//button[@id='checkout']"));
        private IWebElement ContinueShoppigBtn => driver.FindElement(By.XPath("//button[@id='continue-shopping']"));
        private IWebElement RemoveBtn => driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-bolt-t-shirt']"));


        public void CheckOutProduct()
        {
            try
            {
                Assert.IsTrue(CheckOutBtn.Displayed);
                Helper.ClickAction(CheckOutBtn);
                Console.WriteLine("Clicked on the checkout product.");
            }
            catch (Exception ex )
            {

                Console.WriteLine("CheckOut the Product has faild."+ ex);
            }
            
        }

    }
}
