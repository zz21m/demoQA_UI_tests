using Framework.Managers;
using Framework.Models;
using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Drivers;

public class ChromeDriverFactory : BrowserDriverFactory
{
    public override IWebDriver CreateDriver(ConfigurationData configuration, BrowserConfiguration browserConfiguration)
    {
        var options = new ChromeOptions();

        AddArguments(browserConfiguration.Arguments, options.AddArgument);
        AddPreferences(browserConfiguration.Preferences, options.AddUserProfilePreference);

        if (browserConfiguration.Incognito)
        {
            options.AddArgument("--incognito");
        }

        var driver = new ChromeDriver(options);

        if (!string.IsNullOrEmpty(configuration.DownloadDirectory))
        {
            var downloadPath = FileUtility.GetPath(configuration.DownloadDirectory);
            SetDownloadBehavior(driver, downloadPath, browserConfiguration.DownloadBehavior);
        }

        if (configuration.Maximize)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }

    private static void AddPreferences(Dictionary<string, object> preferences, Action<string, object> addPreference)
    {
        foreach (var preference in preferences)
        {
            addPreference(preference.Key, preference.Value);
        }
    }

    private static void SetDownloadBehavior(ChromeDriver driver, string downloadPath, string behavior)
    {
        driver.ExecuteCdpCommand(
            "Page.setDownloadBehavior",
            new Dictionary<string, object>
            {
                ["behavior"] = behavior,
                ["downloadPath"] = downloadPath
            });
    }
}