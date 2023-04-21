using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SauceDemonProject.Utilities;

namespace SauceDemonProject.Pages
{
    class HomePage
    {

        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public IWebElement Menu => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        private IWebElement AllItems => driver.FindElement(By.XPath("//a[@id='inventory_sidebar_link']"));

        private IWebElement About => driver.FindElement(By.XPath("//a[@id='about_sidebar_link']"));

        private IWebElement LogOut => driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));

        private IWebElement ResetAppState => driver.FindElement(By.XPath("//a[@id='reset_sidebar_link']"));


        public void LogoutFromSaceDemo()
        {
            try
            {
                Assert.IsTrue(Menu.Displayed);
                Helper.ClickAction(Menu);
                Assert.IsTrue(LogOut.Displayed);
                Helper.ClickAction(LogOut);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error while logging out: "+ ex);
            }
        }


    }
}
