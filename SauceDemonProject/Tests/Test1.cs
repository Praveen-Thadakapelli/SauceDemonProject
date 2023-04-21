using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SauceDemonProject.Utilities;
using SauceDemonProject.Pages;
using System;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Threading;

namespace SauceDemonProject
{
    [TestClass]
    public class Test1
    {
      public IWebDriver driver;

        LoginPage loginPage => new LoginPage(driver);
        ProductsPage productPage => new ProductsPage(driver);
        PaymentPage paymentPage => new PaymentPage(driver);
        CartPage cartPage => new CartPage(driver);
        HomePage homePage => new HomePage(driver);
        CheckOutOverviewPage checkOutOverviewPage => new CheckOutOverviewPage(driver);


        [TestInitialize]
        public void OpenBrowser()
        {
            try
            { 
                driver = new ChromeDriver();
                Console.WriteLine("Chrome browser has been launched.");        
                driver.Manage().Window.Maximize();
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error while launching the browser: {ex}");
            }
        }

        [TestMethod, TestCategory ("SmokeTest")]
        public void Verify_User_Could_Able_To_Login()
        {

           
            loginPage.Login("standard_user", "secret_sauce");
            Assert.IsTrue(productPage.AppLogo.Displayed);

        }


        [TestMethod]
        public void Add_Aproduct_To_Cart_And_Verify_It_In_CartPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            Assert.IsTrue(productPage.AppLogo.Displayed);
            Thread.Sleep(2000);
            productPage.AddProductToCart();           
            cartPage.CheckOutProduct();
            paymentPage.FillTheAddress();
            Thread.Sleep(2000);
            checkOutOverviewPage.FinishThePurchase();
            checkOutOverviewPage.ThankYouNoteCheck();
            checkOutOverviewPage.GoBackToHome();
            
            homePage.LogoutFromSaceDemo();
            

        }

        [TestMethod, TestCategory("SmokeTest")]
        public void Verify_Locked_Out_Users_Login()
        {


            loginPage.Login("locked_out_user", "secret_sauce");
            loginPage.CheckErrorMsgToast();

        }
        [TestMethod, TestCategory("SmokeTest")]
        public void Verify_Problem_Users_Login()
        {


            loginPage.Login("problem_user", "secret_sauce");
            Assert.IsTrue(productPage.AppLogo.Displayed);

        }
        [TestMethod, TestCategory("SmokeTest")]
        public void VerifyPerformance_Glitch_Users_Login()
        {


            loginPage.Login("performance_glitch_user", "secret_sauce");
            Assert.IsTrue(productPage.AppLogo.Displayed);

        }

        [TestCleanup]
        public void DisposeBrowser()
        {

            driver.Close();
            driver.Quit();

        }
       
    }
}
