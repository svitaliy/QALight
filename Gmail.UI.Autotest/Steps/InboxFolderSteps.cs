using Gmail.UI.Autotests.Helpers;
using Gmail.UI.Autotests.Interfaces;
using Gmail.UI.Autotests.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Steps
{
    [Binding]
    public sealed class InboxFolderSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IinboxFolderPage _inboxPage;

        public InboxFolderSteps(IinboxFolderPage inboxPage, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _inboxPage = inboxPage;
        }

        [Then(@"verify that emails are received by checking Inbox folder")]       
        public void ThenVerifyThatEmailsAreReceived()
        {
            var actualInboxData = (List<MainAreaMsgModel>)_inboxPage.GetInboxInfo();
            var expectedInboxData = ((List<NewMessageModel>)_scenarioContext["newMessages"]);

            var actualInboxSubjects = actualInboxData.Where(x => x.Sender == "me")
                                                     .Select(x => x.Subject).ToList();
            var expectedInboxSubjects = expectedInboxData.Where(x => x.RecipientCc == AtConfiguration.GetConfiguration("Email"))
                                                         .Select(x => x.Subject).ToList();

            Assert.Multiple(() =>
            {
                CollectionAssert.AreEquivalent(expectedInboxSubjects, actualInboxSubjects, 
                                 "Subject verification are fails");
                Assert.AreEqual(expectedInboxSubjects.Count(), actualInboxSubjects.Count(), 
                    $"The number of new messages \"{actualInboxSubjects.Count()}\" " +
                    $"does not match the number of messages sent \"{expectedInboxSubjects.Count()}\"");
            });
        }
    }
}