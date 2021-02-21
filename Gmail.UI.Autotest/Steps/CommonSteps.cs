using Gmail.UI.Autotests.Helpers;
using Gmail.UI.Autotests.Interfaces;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly IBasePage _basePage;
        private readonly ScenarioContext _scenarioContext;
        private readonly IMainPage _mainPage;

        public CommonSteps(IBasePage basePage, IMainPage loginPage, ScenarioContext scenarioContext)
        {
            _basePage = basePage;
            _scenarioContext = scenarioContext;
            _mainPage = loginPage;
        }

        [Given(@"I have navigated to (.*) page")]
        public void NavigateToGmailPage(string app)
        {
            //_loginPage.EnterLogin(AtConfiguration.GetConfiguration("Email"));
            //_loginPage.EnterPassword(AtConfiguration.GetConfiguration("Password"));
        }

        [When(@"click at Request to course button")]
        public void WhenClickAtRequestToCourseButton()
        {
            _mainPage.ClickRequest();
        }


    }
}