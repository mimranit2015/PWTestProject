using Microsoft.VisualStudio.TestTools.UnitTesting;
using PWTestProject.Core;
using PWTestProject.Pages;
using PWTestProject.Models;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PWTestProject.Helpers;

namespace PWTestProject.Tests
{
    [TestClass]
    public class TextBoxTests
    {
        private IPage _page;
        private TextBoxPage _textBoxPage;

        [TestInitialize]
        public async Task SetupAsync()
        {
            // Create browser page
            _page = await DriverFactory.InitPageAsync();

            // Navigate to target page
            await _page.GotoAsync(UrlHelper.TextBoxUrl);

            // Initialize Page Object
            _textBoxPage = new TextBoxPage(_page);
        }

        [TestMethod]
        public async Task ShouldFillAndSubmitTextBoxForm()
        {
            try
            {

                var textBoxData = new TextBoxModel(
                fullName: "John Doe",
                email: "john.doe@example.com",
                currentAddress: "123 Main St, City",
                permanentAddress: "456 Elm St, Town"
            );

                await _textBoxPage.FillFormAsync(textBoxData);
                await _textBoxPage.SubmitAsync();

                StringAssert.Contains(await _textBoxPage.GetNameOutput(), textBoxData.FullName);
                StringAssert.Contains(await _textBoxPage.GetEmailOutput(), textBoxData.Email);
                StringAssert.Contains(await _textBoxPage.GetCurrentAddressOutput(), textBoxData.CurrentAddress);
                StringAssert.Contains(await _textBoxPage.GetPermanentAddressOutput(), textBoxData.PermanentAddress);
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