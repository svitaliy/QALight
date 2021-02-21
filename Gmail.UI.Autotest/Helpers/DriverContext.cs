using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace Gmail.UI.Autotests.Helpers
{
    public static class DriverContext
    {
        private static readonly List<IWebDriver> Drivers = new List<IWebDriver>();
        public static IWebDriver GetDriver(string browser = null)
        {
            var browserName = browser ?? AtConfiguration.GetConfiguration("browser");

            if (browserName.Equals("Chrome", StringComparison.InvariantCultureIgnoreCase))
            {
                var options = new ChromeOptions();
                options.AddArguments("--start-maximized", "--disable-web-security", "--allow-running-insecure-content");
                options.AddLocalStatePreference("intl.accept_languages", "us");
                IWebDriver atWebDriver = new ChromeDriver(options);
                Drivers.Add(atWebDriver);
                return atWebDriver;
            }

            else
            {
                throw new Exception($"Error initializing WebDriver {browserName}");
            }
        }
    }
}