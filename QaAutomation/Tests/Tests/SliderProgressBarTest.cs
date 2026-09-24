namespace Tests;
using Framework.Tests;
using Tests.Forms;
using Tests.Managers;
using Framework.Utilities;
using Tests.PageObjects;

public class SliderProgressBarTest : BaseTest
{
    [Test]
    public void SliderProgressBar() 
    {
        var testData = TestDataManager.GetInstance().TestData.SliderProgressBar;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Slider form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var sliderPage = new SliderPage();

        Assert.That(
            sliderPage.IsOpened(),
            Is.True,
            "Slider form is not opened");

        Logger.Info("Step 3: Set random slider value and verify it");

        var value = RandomDataGenerator.GetInt(
            sliderPage.GetMinValueSlider(),
            sliderPage.GetMaxValueSlider());

        sliderPage.SetSliderValue(value);

        Assert.That(
            sliderPage.GetsliderValueLabel(),
            Is.EqualTo(value),
            "Slider value is incorrect");

        Logger.Info("Step 4: Open Progress Bar form");

        sliderPage.Menu.SelectItem(testData.NextCategory);

        var progressBarPage = new ProgressBarPage();
        Assert.That(
            progressBarPage.IsOpened(),
            Is.True,
            "Progress bar form is not opened");

        Logger.Info("Step 5: Start progress bar");

        progressBarPage.ClickStartStopButton();

        Logger.Info("Step 6: Stop progress bar at target value and verify result");

        progressBarPage.WaitForValueAndStop(
            testData.AgeEngineer);

        var actualValue = progressBarPage.GetProgressValue();

        var errorPercent = MathUtility.CalculateErrorPercent(
            testData.AgeEngineer,
            actualValue);

        Assert.That(
            errorPercent,
            Is.LessThanOrEqualTo(testData.ProgressBarErrorPercent),
            "Progress bar value exceeds allowed error");
    }
}
