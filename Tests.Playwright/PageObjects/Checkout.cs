using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    public static class Checkout
    {
        public static ILocator EMail(this IPage page)
        {
            return page.Locator("id=Email");
        }

        public static ILocator Name(this IPage page)
        {
            return page.Locator("id=Name");
        }

        public static ILocator Address(this IPage page)
        {
            return page.Locator("id=Address");
        }

        public static ILocator Town(this IPage page)
        {
            return page.Locator("id=Town");
        }

        public static ILocator PostalCode(this IPage page)
        {
            return page.Locator("id=PostalCode");
        }

        public static ILocator CreditCard(this IPage page)
        {
            return page.Locator("id=CreditCard");
        }

        public static ILocator CreditCardDate(this IPage page)
        {
            return page.Locator("id=CreditCardDate");
        }

        public static ILocator SubmitButton(this IPage page)
        {
            return page.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" });
        }
        public static async Task<bool> IsCheckOutSuccessfull(this IPage page)
        {
            return await page.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" }).IsVisibleAsync();
        }
}
}
