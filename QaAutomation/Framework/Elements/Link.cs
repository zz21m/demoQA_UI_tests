using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public class Link : BaseElement
    {
        public Link(By locator, string name) : base(locator, name)
        {
        }    
    }
}
