using Framework.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Page
{
    public abstract class BasePage
    {
        private By locator;
        private string Name;

        protected BasePage(By locator, string name)
        {
            this.locator = locator;
            Name = name;
        }

        public bool IsOpened()
        {
            return new Button(locator, Name).IsPresentWithWait();
        }

        public bool IsClosed()
        {
            return new Button(locator, Name).IsNotPresent();
        }
    }
}
