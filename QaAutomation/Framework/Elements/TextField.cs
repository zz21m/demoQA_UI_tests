using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities;

namespace Framework.Elements
{
    public class TextField : InputElement
    {
        public TextField(By locator, string name) : base(locator, name)
        {
        }

        public void SetValue(string text)
        {
            Logger.Info($"Enter text '{text}' into element: {Name}");
            Find().SendKeys(text);
        }

        public void SetValue(int number)
        {
            Logger.Info($"Enter number '{number}' into element: {Name}");
            Find().SendKeys(number.ToString());
        }
    }
}
