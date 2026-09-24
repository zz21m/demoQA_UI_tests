using Framework.Elements;
using Framework.Page;
using Framework.Utilities;
using OpenQA.Selenium;
using System.Globalization;

namespace Tests.PageObjects
{
    public class DatePickerPage : PageWithMenu
    {
        private const string DateFormat = "MM/dd/yyyy";
        private const string DateAndTimeFormat = "MMMM d, yyyy h:mm tt";

        private readonly DatePicker datePicker = new(
            By.Id("datePickerMonthYearInput"),
            "Date field",
            new DatePickerLocators
            {
                YearSelect = By.XPath("//select[contains(@class,'year-select')]"),
                MonthSelect = By.XPath("//select[contains(@class,'month-select')]"),
                DayLocator = date => By.XPath(
                    $"//*[@role='gridcell' and " +
                    $"contains(@aria-label, '{date.ToString("MMMM", CultureInfo.InvariantCulture)}') and " +
                    $"text()='{date.Day}']")
            });

        private readonly DatePicker dateAndTimePicker = new(
            By.Id("dateAndTimePickerInput"),
            "Date and time field",
            new DatePickerLocators
            {
                YearSelect = By.XPath("//button[contains(@class,'year-read')]"),
                MonthSelect = By.XPath("//button[contains(@class,'month-read')]"),
                DayLocator = date => By.XPath(
                    $"//*[@role='gridcell' and " +
                    $"contains(@aria-label, '{date.ToString("MMMM", CultureInfo.InvariantCulture)}') and " +
                    $"text()='{date.Day}']")
            });

        public DatePickerPage() : base(By.XPath("//*[@id='datePickerContainer']"), "DatePicker page")
        {
        }

        public DateTime GetDate()
        {
            return datePicker.GetDateValue(DateFormat);
        }

        public DateTime GetDateAndTime()
        {
            return dateAndTimePicker.GetDateValue(DateAndTimeFormat);
        }

        public void SelectDate(DateTime date)
        {
            datePicker.SetDate(date);
        }
    }
}