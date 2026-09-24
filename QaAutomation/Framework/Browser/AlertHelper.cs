using Framework.Drivers;
using Framework.Managers;
using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace Framework.Browser;

public static class AlertHelper
{
    public static string GetAlertText()
    {
        Logger.Info($"Get text from alert");

        var text = WaitForAlert().Text;

        Logger.Info($"Alert text: {text}");

        return text;
    }

    public static void AcceptAlert()
    {
        Logger.Info("Accept alert");
        WaitForAlert().Accept();
    }

    public static bool IsAlertPresent()
    {
        try
        {
            DriverManager.Driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    public static void SendKeysAlert(string text)
    {
        Logger.Info($"Enter text into alert: {text}");
        WaitForAlert().SendKeys(text);
    }

    private static IAlert WaitForAlert()
    {
        Logger.Info("Wait for alert to appear");

        var wait = new WebDriverWait(
            DriverManager.Driver,
            TimeSpan.FromSeconds(ConfigManager.Config.Timeout));

        return wait.Until(driver =>
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        });
    }
}