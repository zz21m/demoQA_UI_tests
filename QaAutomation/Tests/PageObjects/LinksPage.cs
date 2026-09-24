using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class LinksPage : PageWithMenu
    {
        private Link homeLink = new(By.Id("simpleLink"), "homeLink");
        public LinksPage() : base(By.Id("linkWrapper"), "Links page") 
        {
        } 
        public void GoToHome()
        {
            homeLink.Click();   
        }
    }
}
