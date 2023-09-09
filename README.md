# fundamentals-playwright

## Demos

| Demo | Summary | Runtime |
| :- | :- | :- |
| [Demo 1](#demo-1) | Create a basic .NET Core console app and generate a script | .NET Core |
| [Demo 2](#demo-2) | Run demo 1 in headless mode | .NET Core |
| [Demo 3](#demo-3) | Rerecord navigation but with Trace enabled | .NET Core |

---
## Demo 1

```powershell
mkdir src/demo-csharp
cd src/demo-csharp
dotnet new console -f net6.0
dotnet add package Microsoft.Playwright --version 1.37.1
dotnet build
pwsh .\bin\Debug\net6.0\playwright.ps1 codegen https://www.google.com/ -o ./Program.cs
```

To see what you navigated - headed mode:
```
dotnet run
```

---

## Demo 2

To see it run in headless mode:

Step 1 - set the `Headless` property to true:

```csharp
public static async Task Main()
{
    using var playwright = await Playwright.CreateAsync();
    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = false,
    });
```

Step 2 - `dotnet run`

---

## Demo 3

To see the trace

After line 14 (line 14):

```csharp
var context = await browser.NewContextAsync();
```

enter:

```csharp
var context = await browser.NewContextAsync();
await context.Tracing.StartAsync(new()
{
    Screenshots = true,
    Snapshots = true,
    Sources = true
});
```

then after line `await page.CloseAsync();`, enter:

```csharp
await page.CloseAsync();

await context.Tracing.StopAsync(new()
{
    Path = "trace.zip"
});
```

Now enter this to rerecord your navigation:

```
dotnet run
```

To view the trace:

```powershell
pwsh .\bin\Debug\net6.0\playwright.ps1 show-trace .\trace.zip
```

Example Trace:

![](./assets/2023-09-09-19-41-39.png)
