using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Text;

namespace HRApp.UITests
{
    public static class UITestsBase
    {
        private static WebDriverWait driverWait;

        private static RemoteWebDriver driver;

        public static RemoteWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (driverWait == null || driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return driverWait;
            }
            private set
            {
                driverWait = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            if (Driver == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--headless");
                chromeOptions.AddArgument("--disable-gpu");
                driver = new ChromeDriver(@"C:\PathTo\CHDriverServer");
            }
        }

        public static void StopBrowser()
        {
            Driver.Quit();
            Driver = null;
            BrowserWait = null;
        }
    }
}
}
