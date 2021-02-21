using Gmail.UI.Autotests.Interfaces;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Steps
{
    [Binding]
    public sealed class SideBarSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ISideBarPage _sideBarPage;

        public SideBarSteps(ISideBarPage sideBarPage, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sideBarPage = sideBarPage;

        }

        [When(@"click at Compose button from sidebar")]
        public void WhenClickAtComposeButtonFromSidebar()
        {
            _sideBarPage.ClickCompose();
        }

        [When(@"open (.*) folder from sidebar")]
        public void WhenOpenInboxFolderFromSidebar(string sideBarItem)
        {
            _sideBarPage.SelectOption(sideBarItem);
        }
    }
}