using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.google.com/");

        await page.GetByRole(AriaRole.Button, new() { Name = "Reject all" }).ClickAsync();

        await page.GetByLabel("Search", new() { Exact = true }).ClickAsync();

        await page.GetByLabel("Search", new() { Exact = true }).FillAsync("fujitsu");

        await page.GetByLabel("Search", new() { Exact = true }).PressAsync("Enter");

        await page.GetByRole(AriaRole.Link, new() { Name = "Fujitsu Global : Fujitsu Global Fujitsu https://www.fujitsu.com › global" }).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Fujitsu Uvance Open" }).ClickAsync();

        await page.GetByRole(AriaRole.Tab, new() { Name = "Sustainable Manufacturing" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Read More", Exact = true }).ClickAsync();

    }
}
