using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class EmptyCategoryPage : PageWithMenu
    {
        public EmptyCategoryPage() : base(By.XPath("//*[contains(text(),'Please select an item')]"), "Category page")
        {
        }
    }
}
