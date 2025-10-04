using Microsoft.Playwright;
using SauceDemoTestSuite.Models;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ScenarioContext _scenarioContext; 

        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;
        private readonly ILocator _errorMessage;
        private readonly ILocator _success;

        public LoginPage(IPage page, ScenarioContext scenarioContext) 
        {
            _page = page;
            _scenarioContext = scenarioContext;

            _usernameInput = _page.Locator("[data-test='username']");
            _passwordInput = _page.Locator("[data-test='password']");
            _loginButton = _page.Locator("[data-test='login-button']");
            _errorMessage = _page.Locator("[data-test='error']");
            _success= _page.Locator("[data-test='inventory-container']");
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(User user)
        {
            await _usernameInput.FillAsync(user.Username);
            await _passwordInput.FillAsync(user.Password);
            await _loginButton.ClickAsync();
        }
        public async Task AssertLoginSuccessAsync()
        {
            await Assertions.Expect(_success).ToBeVisibleAsync();
        }
        public async Task AssertLoginErrorDisplayedAsync()
        {
            await Assertions.Expect(_errorMessage).ToBeVisibleAsync();
        }
    }
}
