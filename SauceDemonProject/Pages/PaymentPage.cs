using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SauceDemonProject.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SauceDemonProject.Pages
{
    class PaymentPage
    {
        private IWebDriver driver;
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        private IWebElement FirstName => driver.FindElement(By.XPath("//input[@id='first-name']"));
        private IWebElement LastName => driver.FindElement(By.XPath("//input[@id='last-name']"));
        private IWebElement PostalCode => driver.FindElement(By.XPath("//input[@id='postal-code']"));
        private IWebElement ContinueBtn => driver.FindElement(By.XPath("//input[@name='continue']"));
        private IWebElement CancelBtn => driver.FindElement(By.XPath("//button[@name='cancel']]"));

        public void FillTheAddress() {

            try
            {
                Assert.IsTrue(FirstName.Displayed);
                Helper.SendKeysAfterClear(FirstName, "Sauce");

                Assert.IsTrue(LastName.Displayed);
                Helper.SendKeysAfterClear(LastName, "Demo");

                Assert.IsTrue(PostalCode.Displayed);
                Helper.SendKeysAfterClear(PostalCode, "500058");

                Assert.IsTrue(ContinueBtn.Displayed);
                Helper.ClickAction(ContinueBtn);
                Console.WriteLine("Address has been filled in paymentpage.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is problem at filling payment address." +ex);
                
            }
          
        }

    }
}
