using Framework.Browser;
using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class ProgressBarPage : PageWithMenu
    {
        private Button startStopButton = new(By.Id("startStopButton"), "Start stop button");
        private readonly ProgressBar progressBar = new(By.XPath("//*[@role='progressbar']"), "Progress bar");
        public ProgressBarPage() : base(By.Id("progressBarContainer"), "Progress bar page")
        {
        }

        public void ClickStartStopButton()
        {
            startStopButton.Click();
        }

        public int GetProgressValue()
        {
            return progressBar.GetValue();
        }

        public void WaitForValueAndStop(int targetValue)
        {
            progressBar.WaitForValue(targetValue);
            ClickStartStopButton();
        }
    }
}
