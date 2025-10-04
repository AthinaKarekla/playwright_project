using SauceDemoTestSuite.Models;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }
        [Given("the user navigates to the saucedemo site")]
        public async Task GivenNavigatesToSauceDemo()
        {
            await _loginPage.NavigateAsync();
        }

        [When("a valid user logs in")]
        public async Task WhenUserLogsIn()
        {
            await _loginPage.LoginAsync(UserFactory.ValidUser);
        }

        [Then("the user should see the products page")]
        public async Task ThenUserShouldSeeProductsPage()
        {
            await _loginPage.AssertLoginSuccessAsync();
        }

        [When("an invalid user logs in")]
        public async Task WhenInvalidUserLogsIn()
        {
            await _loginPage.LoginAsync(UserFactory.InvalidUser);
        }

        [Then("the user should see an error message")]
        public async Task ThenUserShouldSeeErrorMessage()
        {
            await _loginPage.AssertLoginErrorDisplayedAsync();
        }
    }
}
    

