using Microsoft.VisualStudio.TestTools.UnitTesting;
using PWTestProject.Core;
using PWTestProject.Pages;
using PWTestProject.Models;
using PWTestProject.Helpers;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PWTestProject.Tests
{
    [TestClass]
    public class CheckBoxTests
    {
        private IPage _page;
        private CheckBoxPage _checkBoxPage;

        [TestInitialize]
        public async Task SetupAsync()
        {
            // Initialize Playwright page using DriverFactory
            _page = await DriverFactory.InitPageAsync();

            // Navigate to the checkbox page
            await _page.GotoAsync(UrlHelper.CheckBoxUrl);

            // Initialize page object
            _checkBoxPage = new CheckBoxPage(_page);
        }

        [TestMethod]
        public async Task ShouldSelectDesktopAndVerify()
        {
            try
            {
                // Test data
                var checkBoxData = new CheckBoxModel(desktop: true);

                // Expand all and select checkboxes
                await _checkBoxPage.ExpandAllAsync();
                await _checkBoxPage.SelectCheckboxesAsync(checkBoxData);

                // Verify result contains "desktop"
                var result = await _checkBoxPage.GetResultTextAsync();
                StringAssert.Contains(result.ToLower(), "desktop");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed due to an exception: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task ShouldSelectMultipleCheckboxesAndVerify()
        {
            try
            {
                var checkBoxData = new CheckBoxModel(desktop: true, documents: true, downloads: true);

                await _checkBoxPage.ExpandAllAsync();
                await _checkBoxPage.SelectCheckboxesAsync(checkBoxData);

                var result = await _checkBoxPage.GetResultTextAsync();
                StringAssert.Contains(result.ToLower(), "desktop");
                StringAssert.Contains(result.ToLower(), "documents");
                StringAssert.Contains(result.ToLower(), "downloads");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed due to an exception: {ex.Message}");
            }
        }

        [TestCleanup]
        public async Task CleanupAsync()
        {
            await DriverFactory.CleanupAsync();
        }
    }
}