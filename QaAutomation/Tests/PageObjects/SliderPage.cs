using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Elements;

namespace Tests.PageObjects
{
    public class SliderPage : PageWithMenu
    {
        private readonly Slider slider = new(By.Id("slider"), "Slider");
        private readonly TextField sliderValueLabel = new(By.Id("sliderValue"), "Slider value");

        public SliderPage() : base(By.Id("sliderContainer"), "Slider page")
        {
        }
        public int GetMinValueSlider()
        {
            return slider.GetMinValue();
        }

        public int GetMaxValueSlider()
        {
            return slider.GetMaxValue();
        }
        public void SetSliderValue(int value)
        {
            slider.SetValue(value);
        }

        public int GetsliderValueLabel()
        {
            return int.Parse(sliderValueLabel.GetValue());
        }
    }
}
