using Gmail.UI.Autotest;
using Gmail.UI.Autotests.Interfaces;
using Gmail.UI.Autotests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gmail.UI.Autotests.Pages
{
    public class SentFolderPage: BasePage, ISentFolderPage
    {
        #region
        private IEnumerable<IWebElement> SentTableRows =>
                _webDriver.FindElements(By.XPath("//table[@id]/tbody/tr[contains(@data-tooltip,'') " +
                    "and contains(@draggable,'')]/td[@role='gridcell']/div/span[@data-hovercard-id]/../../.."));

        private const string Sender = "/td[@role='gridcell']/div/span[@data-hovercard-id]/..";
        private const string Subject = "/td[@role='gridcell']/div/span[@data-hovercard-id]/../../../td[5]/div/div/span";
        #endregion

        private readonly IWebDriver _webDriver;
        public SentFolderPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public IEnumerable<MainAreaMsgModel> GetSentFolderInfo(int maxCount)
        {
            var deltaSentEmails = maxCount - SentTableRows.Count();

            if (deltaSentEmails < 0)
            {
                throw new Exception($"Insufficient number of emails sent" +
                        $" \n Please try add to the test \"{deltaSentEmails}\" sent emails");
            }                

            var result = new List<MainAreaMsgModel>();
            foreach (var sentMessage in SentTableRows.Take(maxCount))
            {
                result.Add(new MainAreaMsgModel()
                {
                    Sender = sentMessage.FindElement(By.XPath(Sender)).Text,
                    Subject = sentMessage.FindElement(By.XPath(Subject)).Text
                });
            }
            return result;
        }
    }
}