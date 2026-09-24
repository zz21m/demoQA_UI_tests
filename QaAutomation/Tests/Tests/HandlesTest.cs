using Framework.Browser;
using Framework.Tests;
using Framework.Utilities;
using Tests.Managers;
using Tests.PageObjects;

namespace Tests;

public class HandlesTest : BaseTest
{
    [Test]
    public void Handles()
    {
        var testData = TestDataManager.GetInstance().TestData.Handles;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(mainPage.IsOpened(), Is.True, "Main page is not opened");

        Logger.Info("Step 2: Open Browser Windows form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var emptyCategoryPage = new EmptyCategoryPage();
        emptyCategoryPage.Menu.SelectItem(testData.Category);

        var browserWindowsPage = new BrowserWindowsPage();

        Assert.That(browserWindowsPage.IsOpened(), Is.True, "Browser windows form is not opened");

        Logger.Info("Step 3: Open new tab and verify sample page");

        var originalWindow = WindowHelper.GetCurrentWindowHandle();

        WindowHelper.SwitchToNewWindow(browserWindowsPage.ClickTabButton);

        var samplePage = new SamplePage();

        Assert.That(samplePage.IsOpened(), Is.True, "Sample page is not opened");

        Logger.Info("Step 4: Close current tab and return to Browser Windows");

        WindowHelper.CloseWindow();
        WindowHelper.SwitchToWindow(originalWindow);

        Assert.That(browserWindowsPage.IsOpened(), Is.True, "Browser windows form is not opened");

        Logger.Info("Step 5: Open Links form");

        browserWindowsPage.Menu.SelectCategory(testData.NextCategoryList);
        browserWindowsPage.Menu.SelectItem(testData.NextCategory);

        var linksPage = new LinksPage();

        Assert.That(linksPage.IsOpened(), Is.True, "Links form is not opened");

        Logger.Info("Step 6: Open Home link in new tab");

        WindowHelper.SwitchToNewWindow(linksPage.GoToHome);

        Assert.That(mainPage.IsOpened(), Is.True, "Main page is not opened");

        Logger.Info("Step 7: Switch back to previous tab");

        WindowHelper.SwitchToWindow(originalWindow);

        Assert.That(linksPage.IsOpened(), Is.True, "Links form is not opened");
    }
}
