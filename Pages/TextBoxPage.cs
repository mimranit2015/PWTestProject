using Microsoft.Playwright;
using PWTestProject.Models;
using System.Threading.Tasks;

namespace PWTestProject.Pages
{
    public class TextBoxPage
    {
        private readonly IPage _page;

        public TextBoxPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator FullNameInput => _page.Locator("#userName");
        private ILocator EmailInput => _page.Locator("#userEmail");
        private ILocator CurrentAddressInput => _page.Locator("#currentAddress");
        private ILocator PermanentAddressInput => _page.Locator("#permanentAddress");
        private ILocator SubmitButton => _page.Locator("#submit");

        // Result locators
        private ILocator NameOutput => _page.Locator("#name");
        private ILocator EmailOutput => _page.Locator("#email");
        private ILocator CurrentAddressOutput => _page.Locator("p#currentAddress");
        private ILocator PermanentAddressOutput => _page.Locator("p#permanentAddress");

        // Actions
        public async Task FillFormAsync(TextBoxModel model)
        {
            await FullNameInput.FillAsync(model.FullName);
            await EmailInput.FillAsync(model.Email);
            await CurrentAddressInput.FillAsync(model.CurrentAddress);
            await PermanentAddressInput.FillAsync(model.PermanentAddress);
        }

        public async Task SubmitAsync() => await SubmitButton.ClickAsync();

        // Assertions
        public async Task<string> GetNameOutput() => await NameOutput.InnerTextAsync();
        public async Task<string> GetEmailOutput() => await EmailOutput.InnerTextAsync();
        public async Task<string> GetCurrentAddressOutput() => await CurrentAddressOutput.InnerTextAsync();
        public async Task<string> GetPermanentAddressOutput() => await PermanentAddressOutput.InnerTextAsync();
    }
}