using PWTestProject.Constants;
using Microsoft.Extensions.Configuration;

namespace PWTestProject.Core
{
    public static class UrlHelper
    {
        private static readonly IConfigurationRoot _config;

        static UrlHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("Config/appsettings.json")
                .Build();
        }

        public static string BaseUrl => _config["BaseUrl"];

        public static string TextBoxUrl => $"{BaseUrl}/text-box";
    }
}

/*
namespace PWTestProject.Helpers
{
    public static class UrlHelper
    {
        public static string GetTextBoxPageUrl()
        {
            return $"{TestConstants.BaseUrl}{TestConstants.TextBoxPagePath}";
        }
    }
}
*/