using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SauceDemonProject.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace SauceDemonProject.Pages
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        private IWebElement UserName => driver.FindElement(By.XPath("//input[@id='user-name']"));
        private IWebElement Password=> driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton=> driver.FindElement(By.XPath("//input[@id='login-button']"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));

        public void Login(string userName, string pass)
        {
            try
            {
                Assert.IsTrue(UserName.Displayed);
                Helper.SendKeysAfterClear(UserName, userName);
                Console.WriteLine("Username has been entered.");

                Assert.IsTrue(Password.Displayed);
                Helper.SendKeysAfterClear(Password, pass);
                Console.WriteLine("Password has been entered");


                Assert.IsTrue(LoginButton.Displayed);                             
                LoginButton.Click();
                Console.WriteLine($"Logged in as {userName}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Login was faild: {ex}");
            }
            
           
        }

        public void CheckErrorMsgToast()
        {
            Assert.IsTrue(ErrorMessage.Displayed);
            Console.WriteLine(ErrorMessage.Text);
        }
    }
}
