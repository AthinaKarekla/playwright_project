using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite
{
    public class ProductsPage
    {
        protected readonly IPage _page;
        protected readonly ScenarioContext _scenariocontext; private ILocator SortDropdown => _page.Locator("[data-test='product-sort-container']");

        private ILocator InventoryItemPrice => _page.Locator("[data-test='inventory-item-price']");
        private ILocator ActiveOption => _page.Locator("[data-test='active-option']");

        public ProductsPage(IPage page, ScenarioContext scenarioContext)
        {
            _page = page;
            _scenariocontext = scenarioContext;

        }
        public async Task SortByPriceLowToHighAsync()
        {
            await SortDropdown.ClickAsync();
            await SortDropdown.SelectOptionAsync(new SelectOptionValue { Value = "lohi" });
            await Assertions.Expect(ActiveOption).ToHaveTextAsync("Price (low to high)");

        }
        public async Task SortByPriceHighToLowAsync()
        {
            await SortDropdown.ClickAsync();
            await SortDropdown.SelectOptionAsync(new SelectOptionValue { Value = "hilo" });
            await Assertions.Expect(ActiveOption).ToHaveTextAsync("Price (high to low)");

        }

        public async Task AssertProductsSortedAscendingAsync()
        {
            var prices = await InventoryItemPrice.AllInnerTextsAsync();
            Console.WriteLine("here: " + string.Join(", ", prices));
        }

        public async Task AssertProductsSortedDescendingAsync()
        {
            var prices =await InventoryItemPrice.AllInnerTextsAsync();
            Console.WriteLine("here: " + string.Join(", ", prices));
        }
    }
}
