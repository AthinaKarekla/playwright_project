using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IBrowser _browser;
        private IPage _page;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user navigates to the saucedemo site")]
        public async Task GivenNavigatesToSauceDemo()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();

            await _page.GotoAsync("https://www.saucedemo.com/");

            _scenarioContext.Set(_page, "CurrentPage");
        }

        [When("a valid user logs in")]
        public async Task WhenUserLogsIn()
        {
            var page = _scenarioContext.Get<IPage>("CurrentPage");
            await page.FillAsync("#user-name", "standard_user");
            await page.FillAsync("#password", "secret_sauce");
            await page.ClickAsync("#login-button");
        }

        [When("an invalid user logs in")]
        public async Task WhenInvalidUserLogsIn()
        {
            var page = _scenarioContext.Get<IPage>("CurrentPage");
            await page.FillAsync("#user-name", "invalid_user");
            await page.FillAsync("#password", "wrong_password");
            await page.ClickAsync("#login-button");
        }

        [Then("the user should see an error message")]
        public async Task ThenUserShouldSeeErrorMessage()
        {
            var page = _scenarioContext.Get<IPage>("CurrentPage");
            var errorMessage = page.Locator("[data-test='error']");
            await Assertions.Expect(errorMessage).ToBeVisibleAsync();
        }

        [Then("the user should see the products page")]
        public async Task ThenUserShouldSeeProducts()
        {
            var page = _scenarioContext.Get<IPage>("CurrentPage");
            var inventory = page.Locator(".inventory_list");
            await Assertions.Expect(inventory).ToBeVisibleAsync();
        }
    }
}
