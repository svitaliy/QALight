using Gmail.UI.Autotests.Interfaces;
using OpenQA.Selenium;

namespace Gmail.UI.Autotest
{
    public class BasePage : IBasePage
    {
        private readonly IWebDriver _webDriver;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}