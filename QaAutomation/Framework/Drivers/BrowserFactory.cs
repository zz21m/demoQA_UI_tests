using Framework.Models;
using OpenQA.Selenium;

namespace Framework.Drivers;

public class BrowserFactory
{
    private static readonly Dictionary<string, BrowserDriverFactory> Factories = new()
    {
        [BrowserType.Chrome] = new ChromeDriverFactory(),
        [BrowserType.Firefox] = new FirefoxDriverFactory()
    };

    public IWebDriver CreateDriver(ConfigurationData configuration)
    {
        var browserConfiguration = configuration.Browsers[configuration.Browser];

        if (!Factories.TryGetValue(configuration.Browser.ToLower(), out var factory))
        {
            throw new NotSupportedException($"Browser '{configuration.Browser}' is not supported");
        }

        return factory.CreateDriver(configuration, browserConfiguration);
    }
}