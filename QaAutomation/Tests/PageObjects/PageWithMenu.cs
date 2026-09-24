using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Forms;

namespace Tests.PageObjects
{
    public abstract class PageWithMenu : BasePage
    {
        public CategoryForm Menu { get; } = new();
        protected PageWithMenu(By locator, string name) : base(locator, name)
        {
        }
    }
}
