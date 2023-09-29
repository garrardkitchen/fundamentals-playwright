// using Microsoft.Playwright;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         using var playwright = await Playwright.CreateAsync();
//         await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions{
//             Headless = true,
//             Timeout = (1000 * 180),
//             Args = new string[] {"--disable-gpu"}
//         });
//         var context = await browser.NewContextAsync(new BrowserNewContextOptions{
//             IgnoreHTTPSErrors = true
//         });
//         var page = await context.NewPageAsync();
//         await page.GotoAsync("https://google.com");
//         var content = await page.ContentAsync();
//         bool isGooglePresent = content.Contains("google", StringComparison.OrdinalIgnoreCase);
//         Console.WriteLine($"Is 'google' present on the page? {isGooglePresent}");
//     }
// }


// using Microsoft.Playwright;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         using var playwright = await Playwright.CreateAsync();
//         await using var browser = await playwright.Firefox.LaunchAsync();
//         var page = await browser.NewPageAsync();
//         await page.GotoAsync("https://google.com");
//         var content = await page.ContentAsync();
//         bool isGooglePresent = content.Contains("google", StringComparison.OrdinalIgnoreCase);
//         Console.WriteLine($"Is 'google' present on the page? {isGooglePresent}");
//     }
// }

using Microsoft.Playwright;

class Program
{
    static async Task Main(string[] args)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://google.com");
        var content = await page.ContentAsync();
        bool isGooglePresent = content.Contains("google", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"Is 'google' present on the page? {isGooglePresent}");
    }
}


