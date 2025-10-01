using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PWTestProject.Core;
using PWTestProject.Helpers;


namespace PWTestProject.Tests
{
    public class BaseTest
    {
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IBrowserContext _context;
        protected IPage _page;

        private const string BrowserName = "chromium"; // change to "firefox" or "webkit" if needed
        private const bool HeadlessMode = true;

        [TestInitialize]
        public async Task Setup()
        {
            // Initialize Playwright and browser using DriverFactory, which reads config automatically
            _page = await DriverFactory.InitPageAsync();

            // Optionally, store context and browser references if needed
            _context = _page.Context;
            _browser = _context.Browser;
        }
        [TestCleanup]
        public async Task Teardown()
        {
            await _context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}