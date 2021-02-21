using Gmail.UI.Autotests.Interfaces;
using System.Linq;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Steps
{
    [Binding]
    public sealed class SentFolderSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ISentFolderPage _sentFolderPage;

        public SentFolderSteps(ISentFolderPage sentFolderPage, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sentFolderPage = sentFolderPage;
        }

        [Then(@"save first (.*) subjects at Sent folder")]
        public void ThenSaveFirstEmailsAtSentFolder(int number)
        {
           var actualResult = _sentFolderPage.GetSentFolderInfo(number);
            _scenarioContext["sentEmailSubjects"] = actualResult.Select(x => x.Subject);
        }
    }
}