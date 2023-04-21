using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    public static class Main
    {
        public static ILocator Concerts(this IPage page, string concertName)
        {
            return page.GetByRole(AriaRole.Row)
                .Filter(new() { HasText = concertName });
        }

        public static async Task GoToConcertDetails(this ILocator element)
        {
            await element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync();
        }
}
}