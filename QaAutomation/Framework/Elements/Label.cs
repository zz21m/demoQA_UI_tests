using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name) : base(locator, name)
        {
        }
    }
}