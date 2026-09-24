using Framework.Browser;
using Framework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public class ProgressBar : BaseElement
    {
        private const string ValueAttribute = "aria-valuenow";

        public ProgressBar(By locator, string name) : base(locator, name)
        {
        }

        public int GetValue()
        {
            return int.Parse(Find().GetAttribute(ValueAttribute));
        }

        public void WaitForValue(int targetValue)
        {

            Logger.Info($"Wait for progress bar value to reach '{targetValue}' for element: {Name}");

            var element = Find();

            WaitHelper.WaitUntil(_ => int.Parse(element.GetAttribute(ValueAttribute)) >= targetValue);
        }
    }
}
