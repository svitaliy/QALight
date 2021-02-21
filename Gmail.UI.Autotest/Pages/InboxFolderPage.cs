using Gmail.UI.Autotest;
using Gmail.UI.Autotests.Interfaces;
using Gmail.UI.Autotests.Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Gmail.UI.Autotests.Pages
{
    public class InboxFolderPage : BasePage, IinboxFolderPage
    {
        #region
        private IEnumerable<IWebElement> InboxTableRows =>
                _webDriver.FindElements(By.CssSelector("tbody>[role='row']"));

        private const string Sender = "//tr[contains(@role,'row')]//td[4]/div[2]//span[@email]";
        private const string Subject ="//tr[contains(@role,'row')]//td[5]//span[@id]/span";        
        #endregion

        private readonly IWebDriver _webDriver;
        public InboxFolderPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public IEnumerable<MainAreaMsgModel> GetInboxInfo()
        {
            var result = new List<MainAreaMsgModel>();
            foreach (var inbox in InboxTableRows)
            {
                result.Add(new MainAreaMsgModel()
                {
                    Sender = inbox.FindElement(By.XPath(Sender)).Text,
                    Subject = inbox.FindElement(By.XPath(Subject)).Text
                });
            }
            return result;
        }
    }
}