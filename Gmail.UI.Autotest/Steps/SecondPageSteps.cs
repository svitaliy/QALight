using Gmail.UI.Autotests.Interfaces;
using Gmail.UI.Autotests.Models;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Steps
{
    [Binding]
    public sealed class SecondPageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ISecondPage _newMessagePage;

        public SecondPageSteps(ISecondPage newMessagePage, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _newMessagePage = newMessagePage;
        }

        [When(@"populate (.*) as recipient, (.*) as CC, (.*) as subject, (.*) as message body")]
        public void WhenPopulateFieldsAtNewMessagePage(string emailTo, string emailCC, string topic, string bodyMsg)
        {
            var messages = new List<NewMessageModel>();

            var initNewMessage = new NewMessageModel
            {
                RecipientTo = emailTo,
                RecipientCc = emailCC,
                MsgBody = bodyMsg,
                Subject = topic
            };

            messages.Add(initNewMessage);
            _scenarioContext["newMessages"] = messages;
            _newMessagePage.FillNewMessage(initNewMessage);
        }

        [When(@"send new message")]
        public void WhenSendNewMessage()
        {
            _newMessagePage.SendMessage();
        }


        [Then(@"verify that (.*) is shown")]
        public void ThenVerifyThatНапрямкиНавчанняIsShown(string blockName)
        {
            var actualResult = _newMessagePage.GetBlockName();
            var expectedResult = blockName;

            Assert.AreEqual(expectedResult, actualResult, $"Name block is not shown. The {actualResult} is shown");
        }
    }
}