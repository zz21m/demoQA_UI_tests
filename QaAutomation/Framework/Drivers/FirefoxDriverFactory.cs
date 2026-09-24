using Framework.Models;
using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Framework.Drivers;

public class FirefoxDriverFactory : BrowserDriverFactory
{
    public override IWebDriver CreateDriver(ConfigurationData configuration, BrowserConfiguration browserConfiguration)
    {
        var options = new FirefoxOptions();

        AddArguments(browserConfiguration.Arguments, options.AddArgument);
        AddPreferences(browserConfiguration.Preferences, options);

        if (!string.IsNullOrEmpty(configuration.DownloadDirectory))
        {
            var downloadPath = FileUtility.GetPath(configuration.DownloadDirectory);
            options.SetPreference("browser.download.dir", downloadPath);
        }

        if (browserConfiguration.Incognito)
        {
            options.AddArgument("-private");
        }

        var driver = new FirefoxDriver(options);

        if (configuration.Maximize)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }

    private static void AddPreferences(Dictionary<string, object> preferences, FirefoxOptions options)
    {
        foreach (var preference in preferences)
        {
            switch (preference.Value)
            {
                case string value:
                    options.SetPreference(preference.Key, value);
                    break;

                case bool value:
                    options.SetPreference(preference.Key, value);
                    break;

                case int value:
                    options.SetPreference(preference.Key, value);
                    break;

                default:
                    throw new ArgumentException($"Unsupported preference type: {preference.Value.GetType()}");
            }
        }
    }
}