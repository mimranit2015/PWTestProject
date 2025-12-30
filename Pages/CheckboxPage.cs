using Microsoft.Playwright;
using System.Threading.Tasks;
using PWTestProject.Models;

namespace PWTestProject.Pages
{
    public class CheckBoxPage
    {
        private readonly IPage _page;

        // Locators
        private readonly string expandAllButton = "button[title='Expand all']";
        private readonly string desktopCheckBox = "label[for='tree-node-desktop'] span.rct-checkbox";
        private readonly string documentsCheckBox = "label[for='tree-node-documents'] span.rct-checkbox";
        private readonly string downloadsCheckBox = "label[for='tree-node-downloads'] span.rct-checkbox";
        private readonly string resultText = "#result";

        public CheckBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task ExpandAllAsync()
        {
            await _page.ClickAsync(expandAllButton);
        }

        public async Task SelectCheckboxesAsync(CheckBoxModel data)
        {
            if (data.Desktop)
                await _page.ClickAsync(desktopCheckBox);

            if (data.Documents)
                await _page.ClickAsync(documentsCheckBox);

            if (data.Downloads)
                await _page.ClickAsync(downloadsCheckBox);
        }

        public async Task<string> GetResultTextAsync()
        {
            return await _page.InnerTextAsync(resultText);
        }
    }
}
