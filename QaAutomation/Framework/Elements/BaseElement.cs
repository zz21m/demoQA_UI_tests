using Framework.Browser;
using Framework.Drivers;
using Framework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public abstract class BaseElement
    {
        protected By Locator { get; }
        protected string Name { get; }

        protected BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        public string GetText()
        {
            Logger.Info($"Get text from element '{Name}'");

            var text = Find().Text;

            Logger.Info($"Text from element '{Name}': {text}");

            return text;
        }

        protected IWebElement Find()
        {
            Logger.Info($"Find element: {Name}");
            return WaitHelper.WaitForVisibleElement(Locator);
        }

        protected IWebElement FindForInteraction()
        {
            Logger.Info($"Find element: {Name}");
            return WaitHelper.WaitForClickableElement(Locator);
        }

        public void Click()
        {
            Logger.Info($"Click on element: {Name}");

            try
            {
                FindForInteraction().Click();
            }
            catch (ElementClickInterceptedException)
            {
                Logger.Info($"Element intercepted, scrolling to: {Name}");
                var element = Find();

                JavaScriptUtility.ScrollToElement(element);
                WaitHelper.WaitUntilElementStopsMoving(element);

                FindForInteraction().Click();
            }
        }

        public bool IsPresentWithWait()
        {
            return WaitHelper.WaitForPresentElement(Locator) != null;
        }

        public bool IsPresent()
        {
            return DriverManager.Driver
                .FindElements(Locator)
                .Count > 0;
        }

        public bool IsNotPresent()
        {
            return WaitHelper.WaitUntilNotPresent(Locator);
        }
    }
}