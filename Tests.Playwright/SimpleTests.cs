using Microsoft.Playwright;
using Tests.Playwright.PageObjects;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public async Task SmokeTest()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://20.103.208.20/");

            await page.Concerts("John Egbert Live John Egbert")
                .GoToConcertDetails();

            //await page.GetByRole(AriaRole.Row)
            //    .Filter(new() { HasText = "John Egbert Live John Egbert" })
            //    .GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" })
            //    .ClickAsync();

            page.PlaceOrderButton().PlaceOrder();
            //await page.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" }).ClickAsync();

            await page.CheckOutButton().GoToCheckout();
            //await page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" }).ClickAsync();

            await page.EMail().FillAsync("norschel@xpirit.com");
            await page.Name().FillAsync("Nico Orschel");
            await page.Address().FillAsync("Irgendwo in Eschborn");
            await page.Town().FillAsync("Eschborn");
            await page.PostalCode().FillAsync("60606");
            await page.CreditCard().FillAsync("4303651055386607");
            await page.CreditCardDate().FillAsync("09/28");

            //await page.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" }).ClickAsync();
            await page.SubmitButton().ClickAsync();

            await page.IsCheckOutSuccessfull();
        }
    }
}