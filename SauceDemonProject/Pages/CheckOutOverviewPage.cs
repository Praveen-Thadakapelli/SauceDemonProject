using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SauceDemonProject.Utilities;


namespace SauceDemonProject.Pages
{
   
        class CheckOutOverviewPage
        {
            private IWebDriver driver;
            public CheckOutOverviewPage(IWebDriver driver)
            {
                this.driver = driver;

            }


            private IWebElement ProductName => driver.FindElement(By.XPath("//div[normalize-space()='Sauce Labs Bike Light']"));
            private IWebElement FinishBtn => driver.FindElement(By.XPath("//button[@name='finish']"));
            private IWebElement CancelButton => driver.FindElement(By.XPath("//button[@name='cancel']"));
            private IWebElement ThankYouNote => driver.FindElement(By.XPath("//div[@id='checkout_complete_container']//div"));
            private IWebElement BackToHomeBtn => driver.FindElement(By.XPath("//button[@id='back-to-products']"));



        public void CancelThePurchase()
          {
            Assert.IsTrue(CancelButton.Displayed);
            Helper.ClickAction(CancelButton);
          }

          public void FinishThePurchase()
        {
            try
            {
                Assert.IsTrue(FinishBtn.Displayed);
                Helper.ClickAction(FinishBtn);
                Console.WriteLine("Product has been purchased.");
            }
            catch (Exception ex)
            {

                Console.WriteLine("There is problem finishing the purchase."+ ex);
            }
            

        }
        public void ThankYouNoteCheck()
        {
            Assert.IsTrue(ThankYouNote.Displayed);
            Console.WriteLine(ThankYouNote.Text);
        }

        public void GoBackToHome()
        {
            Assert.IsTrue(BackToHomeBtn.Displayed);
            Helper.ClickAction(BackToHomeBtn);
            Console.WriteLine("Clicked on BackHome button.");
        }
    }

        
}
