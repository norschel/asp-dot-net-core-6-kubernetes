using Microsoft.Playwright;
using Tests.Playwright.PageObjects;
using static System.Net.WebRequestMethods;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        private TestContext _context;

        [ClassInitialize]
        public void TestInit(TestContext context)
        {
            _context = context;
        }


        [TestMethod]
        public async Task SmokeTest()
        {
            var page = await InitBrowserSession();
            var url = GetServerUrl();
            await page.GotoAsync(url);
            await page.Concerts("John Egbert Live John Egbert")
                .GoToConcertDetails();
            page.PlaceOrderButton().PlaceOrder();
            await page.CheckOutButton().GoToCheckout();
            await page.EMail().FillAsync("norschel@xpirit.com");
            await page.Name().FillAsync("Nico Orschel");
            await page.Address().FillAsync("Irgendwo in Eschborn");
            await page.Town().FillAsync("Eschborn");
            await page.PostalCode().FillAsync("60606");
            await page.CreditCard().FillAsync("4303651055386607");
            await page.CreditCardDate().FillAsync("09/28");
            await page.SubmitButton().ClickAsync();
            await page.IsCheckOutSuccessfull();
        }

        private static async Task<IPage> InitBrowserSession()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            return page;
        }

        private string GetServerUrl()
        {
            var url =
                _context.Properties["TicketServerUrl"]?.ToString();
            if (url == null)
            {
                url = "http://20.103.208.20/";
            }

            return url;
        }
    }
}