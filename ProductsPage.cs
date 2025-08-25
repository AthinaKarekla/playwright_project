using Microsoft.Playwright;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class ProductsPage
    {
        private readonly IPage _page;

        public ProductsPage(IPage page)
        {
            _page = page;
        }

        private ILocator InventoryList => _page.Locator(".inventory_list");

        public async Task AssertLoginSuccessfulAsync()
        {
            await Assertions.Expect(InventoryList).ToBeVisibleAsync();
        }

        public async Task SortByPriceLowToHighAsync()
        {
            var sortDropdown = _page.Locator("[data-test='product_sort_container']");
            await sortDropdown.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await sortDropdown.SelectOptionAsync(new SelectOptionValue { Value = "lohi" });
        }

        public async Task AssertProductsSortedAscendingAsync()
        {
            var prices = await _page.Locator(".inventory_item_price").AllInnerTextsAsync();
            var numericPrices = prices
                .Select(p => decimal.Parse(p.Replace("$", ""), System.Globalization.CultureInfo.InvariantCulture))
                .ToList();

            var sortedPrices = numericPrices.OrderBy(p => p).ToList();
            Assert.That(numericPrices, Is.EqualTo(sortedPrices), "The products are not sorted in ascending order.");
        }

        public async Task SortByPriceHighToLowAsync()
        {
            var sortDropdown = _page.Locator("[data-test='product_sort_container']");
            await sortDropdown.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await sortDropdown.SelectOptionAsync(new SelectOptionValue { Value = "hilo" });
        }

        public async Task AssertProductsSortedDescendingAsync()
        {
            var prices = await _page.Locator(".inventory_item_price").AllInnerTextsAsync();
            var numericPrices = prices
                .Select(p => decimal.Parse(p.Replace("$", ""), System.Globalization.CultureInfo.InvariantCulture))
                .ToList();

            var sortedPrices = numericPrices.OrderByDescending(p => p).ToList();
            Assert.That(numericPrices, Is.EqualTo(sortedPrices), "The products are not sorted in descending order.");
        }
    }
}
