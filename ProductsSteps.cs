using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.StepDefinitions
{
    [Binding]
    public class ProductsSteps
    {
        private readonly ProductsPage _productsPage;
        public ProductsSteps(ProductsPage productspage)
        {
            _productsPage = productspage;
        }

        [When("the user sorts products by price from low to high")]
        public async Task WhenUserSortsProducts()
        {
            await _productsPage.SortByPriceLowToHighAsync();
        }

        [Then("the products should be sorted in ascending order")]
        public async Task ThenProductsShouldBeSorted()
        {
            await _productsPage.AssertProductsSortedAscendingAsync();
        }

        [When("the user sorts products by price from high to low")]
        public async Task WhenUserSortsProductsDescending()
        {
            await _productsPage.SortByPriceHighToLowAsync();
        }

        [Then("the products should be sorted in descending order")]
        public async Task ThenProductsShouldBeSortedDescending()
        {
            await _productsPage.AssertProductsSortedDescendingAsync();
        }
    }
}
