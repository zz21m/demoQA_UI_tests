using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public abstract class InputElement : BaseElement
    {
        private const string ValueAttribute = "value";
        protected InputElement(By locator, string name) : base(locator, name)
        {
        }

        public string GetValue()
        {
            return Find().GetAttribute(ValueAttribute);
        }
    }
}
