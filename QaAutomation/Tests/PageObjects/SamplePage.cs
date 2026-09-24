using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class SamplePage : BasePage
    {
        public SamplePage() : base(By.Id("sampleHeading"), "Sample Page")
        {
        }
    }
}
