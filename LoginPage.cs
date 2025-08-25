using Microsoft.Playwright;
using System.Threading.Tasks;
using SauceDemoTestSuite.Models;
using NUnit.Framework;

namespace SauceDemoTestSuite
{
    public class LoginPage
    {
        private IPage _page = null!;

        private ILocator UsernameInput => _page.Locator("[data-test='username']");
        private ILocator PasswordInput => _page.Locator("[data-test='password']");
        private ILocator LoginButton => _page.Locator("[data-test='login-button']");
        private ILocator ErrorMessage => _page.Locator("[data-test='error']");

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync();
            _page = await context.NewPageAsync();
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(User user)
        {
            await UsernameInput.FillAsync(user.Username);
            await PasswordInput.FillAsync(user.Password);
            await LoginButton.ClickAsync();
        }

        public async Task AssertLoginErrorDisplayedAsync()
        {
            bool isVisible = await ErrorMessage.IsVisibleAsync();
            Assert.IsTrue(isVisible, "Expected error message to be visible after failed login.");
        }

        public IPage GetPage() => _page;
    }
}
