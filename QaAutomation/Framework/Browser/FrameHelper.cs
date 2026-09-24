using Framework.Drivers;
using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.Browser;

public static class FrameHelper
{
    public static void SwitchToFrame(By frameLocator)
    {
        Logger.Info("Switch to frame");
        var frameElement = WaitHelper.WaitForVisibleElement(frameLocator);
        DriverManager.Driver.SwitchTo().Frame(frameElement);
    }

    public static void SwitchToDefaultContent()
    {
        Logger.Info("Switch to default content");
        DriverManager.Driver.SwitchTo().DefaultContent();
    }
}