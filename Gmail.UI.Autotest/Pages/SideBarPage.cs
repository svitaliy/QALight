using Gmail.UI.Autotest;
using Gmail.UI.Autotests.Interfaces;
using OpenQA.Selenium;

namespace Gmail.UI.Autotests.Pages
{
    public class SideBarPage : BasePage, ISideBarPage
    {
        #region Selectors
        private IWebElement SideOption(string option) => 
            _webDriver.FindElement(By.XPath($"//div[@class='wT']//*[@data-tooltip='{option}']"));
        private IWebElement ComposeButton => 
            _webDriver.FindElement(By.XPath("*//div[@role='button' and contains(text(), 'Compose')]"));
        #endregion

        private readonly IWebDriver _webDriver;
        public SideBarPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public void SelectOption(string option)
        {
            if (SideOption(option).Displayed)
            {                
                SideOption(option).Click();
            }
        }

        public void ClickCompose() => ComposeButton.Click();
    }
}