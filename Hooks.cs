using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.Hooks
{
    [Binding]
    public class PlaywrightHooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _sc;

        public PlaywrightHooks(IObjectContainer container, ScenarioContext sc)
        {
            _container = container;
            _sc = sc;
        }

        [BeforeScenario]
        public async Task StartBrowserAsync()
        {
            var pw = await Playwright.CreateAsync();
            var browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            // Κάνε register στο BoDi για DI στους constructors
            _container.RegisterInstanceAs(pw);
            _container.RegisterInstanceAs(browser);
            _container.RegisterInstanceAs(context);
            _container.RegisterInstanceAs(page);

            // Αν θες να injectαρεις απευθείας LoginPage στα Steps:
            _container.RegisterInstanceAs(new LoginPage(page, _sc));
        }

        [AfterScenario]
        public async Task CleanupAsync()
        {
            if (_container.IsRegistered<IBrowser>())
            {
                var browser = _container.Resolve<IBrowser>();
                await browser.CloseAsync();
            }

            if (_container.IsRegistered<IPlaywright>())
            {
                var pw = _container.Resolve<IPlaywright>();
                pw.Dispose();
            }
        }
    }
}
