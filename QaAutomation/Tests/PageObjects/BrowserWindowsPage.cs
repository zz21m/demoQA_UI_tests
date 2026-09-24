using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class BrowserWindowsPage : PageWithMenu
    {
        private Button newTabButton = new(By.Id("tabButton"), "New tab button");

        public BrowserWindowsPage() : base(By.XPath("//*[contains(@id,'browserWindows')]"), "Browser windows page")
        {

        }
        public void ClickTabButton()
        {
            newTabButton.Click();   
        }
    }
}
