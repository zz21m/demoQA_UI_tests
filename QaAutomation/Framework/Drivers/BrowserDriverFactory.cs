using Framework.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Drivers
{
    public abstract class BrowserDriverFactory
    {
        public abstract IWebDriver CreateDriver(ConfigurationData configuration, BrowserConfiguration browserConfiguration);

        protected static void AddArguments(List<string> arguments, Action<string> addArgument)
        {
            foreach (var argument in arguments)
            {
                addArgument(argument);
            }
        }
    }
}
