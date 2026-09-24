using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Elements
{
    public class DatePickerLocators
    {
        public By YearSelect { get; set; } 
        public By MonthSelect { get; set; } 
        public Func<DateTime, By> DayLocator { get; set; } 
        public Func<DateTime, string> MonthValueSelector { get; set; } = date => (date.Month - 1).ToString();
        public Func<DateTime, string> YearValueSelector { get; set; } = date => date.Year.ToString();
    }
}
