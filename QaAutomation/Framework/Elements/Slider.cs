using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities;

namespace Framework.Elements
{
    public class Slider : BaseElement
    {
        private const string MinAttribute = "min";
        private const string MaxAttribute = "max";
        private const string ValueAttribute = "value";
        public Slider(By locator, string name) : base(locator, name)
        {
        }
        public int GetMinValue()
        {
            return int.Parse(Find().GetAttribute(MinAttribute));
        }

        public int GetMaxValue()
        {
            return int.Parse(Find().GetAttribute(MaxAttribute));
        }

        public void SetValue(int number)
        {
            Logger.Info($"Set slider value '{number}' for element: {Name}");

            Click();

            var element = Find();
            var currentValue = int.Parse(element.GetAttribute(ValueAttribute));

            var key = number > currentValue
                ? Keys.ArrowRight
                : Keys.ArrowLeft;

            for (var i = 0; i < Math.Abs(number - currentValue); i++)
            {
                element.SendKeys(key);
            }
        }   
    }
}
