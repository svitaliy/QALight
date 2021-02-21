using BoDi;
using Gmail.UI.Autotest;
using Gmail.UI.Autotests.Helpers;
using Gmail.UI.Autotests.Interfaces;
using Gmail.UI.Autotests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Gmail.UI.Autotests.Hooks
{
    [Binding]
    public sealed class DependencyHook
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;

        public DependencyHook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }       

        [BeforeScenario(Order = 0)]
        public void CreateApplicationUrl()
        {            
            _webDriver = DriverContext
                .GetDriver(TestContext.Parameters.Get("browser", AtConfiguration.GetConfiguration("Browser")));
           
            _webDriver.Navigate().GoToUrl(AtConfiguration.GetConfiguration("TestUrl"));
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(_webDriver);
            _objectContainer.RegisterTypeAs<BasePage, IBasePage>();
            _objectContainer.RegisterTypeAs<MainPage, IMainPage>();
            _objectContainer.RegisterTypeAs<InboxFolderPage, IinboxFolderPage>();
            _objectContainer.RegisterTypeAs<SecondPage, ISecondPage>();
            _objectContainer.RegisterTypeAs<SideBarPage, ISideBarPage>();
            _objectContainer.RegisterTypeAs<SentFolderPage, ISentFolderPage>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.Quit();
        }
    }
}