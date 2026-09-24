using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name)
        {
        }
    }
}
