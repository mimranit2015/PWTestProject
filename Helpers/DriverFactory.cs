using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PWTestProject.Helpers
{
    public static class DriverFactory
    {
        private static IPlaywright _playwright;
        private static IBrowser _browser;

        /// <summary>
        /// Create the browser with specified parameters
        /// </summary>
        /// <param name="browserName">chromium, firefox, webkit</param>
        /// <param name="headless">true for headless, false to see the browser</param>
        /// <param name="slowMo">optional delay in ms for actions</param>
        public static async Task<IBrowser> CreateBrowserAsync(
            string browserName = "chromium",
            bool headless = false,
            int slowMo = 50)
        {
            _playwright ??= await Playwright.CreateAsync();

            if (_browser != null)
                return _browser;

            browserName = browserName.ToLower();
            Console.WriteLine($"Launching browser: {browserName}, Headless: {headless}, SlowMo: {slowMo}ms");

            _browser = browserName switch
            {
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    SlowMo = slowMo
                }),
                "webkit" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    SlowMo = slowMo
                }),
                _ => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless,
                    SlowMo = slowMo
                })
            };

            return _browser;
        }

        /// <summary>
        /// Initialize a new page
        /// </summary>
        public static async Task<IPage> InitPageAsync(
            string browserName = "chromium",
            bool headless = false,
            int slowMo = 50)
        {
            var browser = await CreateBrowserAsync(browserName, headless, slowMo);
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            return page;
        }

        /// <summary>
        /// Cleanup browser and Playwright
        /// </summary>
        public static async Task CleanupAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }

            _playwright?.Dispose();
            _playwright = null;
        }
    }
}
