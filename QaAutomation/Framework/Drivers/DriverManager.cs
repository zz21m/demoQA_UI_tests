using Framework.Models;
using Framework.Managers;
using OpenQA.Selenium;

namespace Framework.Drivers
{
    public sealed class DriverManager
    {
        private static IWebDriver? _driver;
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {                    
                    _driver = new BrowserFactory().CreateDriver(ConfigManager.Config);
                }
                return _driver;
            }
        }
        public static void QuitDriver()
        {
            if(_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
