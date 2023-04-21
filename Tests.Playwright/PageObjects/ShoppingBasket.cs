using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright.PageObjects
{
    public static class ShoppingBasket
    {
        public static ILocator CheckOutButton(this IPage page)
        {
            return page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" });
        }

        public static async Task GoToCheckout(this ILocator element)
        {
            await element.ClickAsync();
        }
    }
}