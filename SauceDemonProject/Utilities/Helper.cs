using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemonProject.Utilities
{
    public static class Helper
    {
        public static void MoveToElement(IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
        }

        public static void ClickElement(IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.Click(element);
            actions.Build().Perform();

        }
        public static void DoubleClickElement(IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element);
            actions.Build().Perform();
        }

        //public static IWebDriver LanuchBrowser(string browser)
        //{
        //    IWebDriver driver= null;
        //    browser.ToLower();
        //    try
        //    {
        //        if (browser == "chrome")
        //        {
        //            driver = new ChromeDriver();
        //            Console.WriteLine("Chrome browser has been launched.");
        //            return driver;
        //        }

        //        if (browser == "edge")
        //        {
        //            driver = new EdgeDriver();
        //            Console.WriteLine("Edge browser has been launched.");
        //            return driver;
        //        }
        //        if (browser == "firefox")
        //        {
        //            driver = new FirefoxDriver();
        //            Console.WriteLine("Firefox browser has been launched.");
        //            return driver;
        //        }

        //        driver.Manage().Window.Maximize();
        //        driver.Manage().Cookies.DeleteAllCookies();
        //        driver.Navigate().GoToUrl("http://www.google.co.in");
                
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Error while launching the browser: {ex}");
        //    }
                    
        //}

        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
        public static void GotoUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void SendKeysAfterClear(IWebElement element, string str)
        {
            element.Clear();
            element.SendKeys(str);
        }
        public static void ClickAction(IWebElement element)
        {
            element.Click();
           
        }
    
}

  

    public enum BrowserName
    {
        Chrome,
        Edge,
        Firefox

    };
}
