using Framework.Browser;
using Framework.Tests;
using Framework.Utilities;
using Tests.Managers;
using Tests.PageObjects;

namespace Tests;

public class IframeTest : BaseTest
{
    [Test]
    public void Iframe()
    {
        var testData = TestDataManager.GetInstance().TestData.Frames;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Nested Frames form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var nestedFramesPage = new NestedFramesPage();

        Assert.That(
            nestedFramesPage.IsOpened(),
            Is.True,
            "Nested frames form is not opened");

        Assert.That(
            nestedFramesPage.GetParentFrameText(),
            Is.EqualTo(testData.ParentFrameText),
            "Parent frame text is incorrect");

        Assert.That(
            nestedFramesPage.GetChildFrameText(),
            Is.EqualTo(testData.ChildFrameText),
            "Child iframe text is incorrect");

        Logger.Info("Step 3: Open Frames form and compare frame texts");

        nestedFramesPage.Menu.SelectItem(testData.NextCategory);

        var framesPage = new FramesPage();

        Assert.That(
            framesPage.IsOpened(),
            Is.True,
            "Frames form is not opened");

        Assert.That(
            framesPage.GetUpperFrameText(),
            Is.EqualTo(framesPage.GetLowerFrameText()),
            "Text in the upper frame does not match text in the lower frame");
    }
}