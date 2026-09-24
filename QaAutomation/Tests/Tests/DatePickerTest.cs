using Framework.Browser;
using Framework.Tests;
using Framework.Utilities;
using Tests.Forms;
using Tests.Managers;
using Tests.PageObjects;

namespace Tests;

public class DatePickerTest : BaseTest
{
    [Test]
    public void DatePicker()
    {
        var testData = TestDataManager.GetInstance().TestData.DatePicker;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Date Picker form and verify current date and time");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var datePickerPage = new DatePickerPage();

        Assert.That(
            datePickerPage.IsOpened(),
            Is.True,
            "DatePicker form is not opened");

        Assert.That(
            datePickerPage.GetDate(),
            Is.EqualTo(DateTime.Today),
            "Incorrect Select Date value");

        Assert.That(
            datePickerPage.GetDateAndTime(),
            Is.EqualTo(DateTime.Now.Date
            .AddHours(DateTime.Now.Hour)
            .AddMinutes(DateTime.Now.Minute)),
            "Incorrect Select Date value");

        Logger.Info("Step 3: Select nearest February 29 and verify the selected date");

        var expectedDate = DateUtility.GetNearestDate(
            testData.Day,
            testData.Month);

        datePickerPage.SelectDate(expectedDate);

        Assert.That(
            datePickerPage.GetDate(),
            Is.EqualTo(expectedDate),
            "Incorrect selected date");
    }
}
