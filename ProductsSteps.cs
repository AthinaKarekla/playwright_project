using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.StepDefinitions
{
    [Binding]
    public class ProductsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public static ProductsPage ProductsScreen = null!;

        public ProductsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var page = _scenarioContext.Get<Microsoft.Playwright.IPage>("CurrentPage");
            ProductsScreen = new ProductsPage(page);
        }

        [When("the user sorts products by price from low to high")]
        public async Task WhenUserSortsProducts()
        {
            await ProductsScreen.SortByPriceLowToHighAsync();
        }

        [Then("the products should be sorted in ascending order")]
        public async Task ThenProductsShouldBeSorted()
        {
            await ProductsScreen.AssertProductsSortedAscendingAsync();
        }

        [When("the user sorts products by price from high to low")]
        public async Task WhenUserSortsProductsDescending()
        {
            await ProductsScreen.SortByPriceHighToLowAsync();
        }

        [Then("the products should be sorted in descending order")]
        public async Task ThenProductsShouldBeSortedDescending()
        {
            await ProductsScreen.AssertProductsSortedDescendingAsync();
        }
    }
}
