using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright.PageObjects
{
    public static class ConcertDetails
    {
        public static ILocator PlaceOrderButton(this IPage page)
        {
            return page.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
        }

        public static void PlaceOrder(this ILocator element)
        {
            element.ClickAsync();
        }
}
}
