using Framework.Drivers;
using Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Browser
{
    public static class WindowHelper
    {
        public static string GetCurrentWindowHandle()
        {
            return DriverManager.Driver.CurrentWindowHandle;
        }

        public static IReadOnlyCollection<string> GetWindowHandles()
        {
            return DriverManager.Driver.WindowHandles;
        }

        public static void SwitchToWindow(string handle)
        {
            Logger.Info("Switch to window");
            DriverManager.Driver.SwitchTo().Window(handle);
        }

        public static void CloseWindow()
        {
            Logger.Info("Close current window");
            DriverManager.Driver.Close();
        }

        public static void SwitchToNewWindow(Action action)
        {
            var handlesBefore = GetWindowHandles();

            action();

            var newWindow = WaitHelper.WaitUntilNewWindowAppears(handlesBefore);

            SwitchToWindow(newWindow);
        }
    }
}
