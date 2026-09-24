using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class DatePicker : InputElement
    {
        private readonly Select yearSelect;
        private readonly Select monthSelect;
        private readonly DatePickerLocators locators;

        public DatePicker(By locator, string name, DatePickerLocators locators) : base(locator, name)
        {
            this.locators = locators;
            yearSelect = new Select(locators.YearSelect, "Year select");
            monthSelect = new Select(locators.MonthSelect, "Month select");
        }

        public DateTime GetDateValue(string format)
        {
            return DateUtility.ParseDate(GetValue(), format);
        }

        public void SetDate(DateTime date)
        {
            Click();

            SelectMonth(date);
            SelectYear(date);
            SelectDay(date);
        }

        private void SelectMonth(DateTime date)
        {
            monthSelect.SelectByValue(locators.MonthValueSelector(date));
        }

        private void SelectYear(DateTime date)
        {
            yearSelect.SelectByValue(locators.YearValueSelector(date));
        }

        private void SelectDay(DateTime date)
        {
            var day = new Button(
                locators.DayLocator(date),
                $"Day {date} button");

            day.Click();
        }
    }
}