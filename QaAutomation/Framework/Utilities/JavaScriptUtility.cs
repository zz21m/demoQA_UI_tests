using Framework.Browser;
using Framework.Drivers;
using Framework.Elements;
using Framework.Managers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace Framework.Utilities
{
    public static class JavaScriptUtility
    {
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)DriverManager.Driver)
                .ExecuteScript(
                    "arguments[0].scrollIntoView({ block: 'center', inline: 'nearest' });",
                    element);
        }
    }
}