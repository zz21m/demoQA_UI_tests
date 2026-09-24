using Framework.Browser;
using Framework.Tests;
using Framework.Utilities;
using NUnit.Framework;
using Tests.Managers;
using Tests.PageObjects;

namespace Tests;

public class AlertsTest : BaseTest
{
    [Test]
    public void Alerts()
    {
        var testData = TestDataManager.GetInstance().TestData.Alerts;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Alerts form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var alertsPage = new AlertsPage(); 
        
        Assert.That(
            alertsPage.IsOpened(),
            Is.True,
            "Alerts form is not opened");

        Logger.Info("Step 3: Click alert button");

        alertsPage.ClickAlertButton();

        Assert.That(
            AlertHelper.GetAlertText(),
            Is.EqualTo(testData.AlertText),
            "Alert text is incorrect");

        Logger.Info("Step 4: Accept alert");

        AlertHelper.AcceptAlert();

        Assert.That(
            AlertHelper.IsAlertPresent(),
            Is.False,
            "Alert was not closed after clicking OK");

        Logger.Info("Step 5: Click confirm button");

        alertsPage.ClickConfirmButton();

        Assert.That(
            AlertHelper.GetAlertText(),
            Is.EqualTo(testData.ConfirmText),
            "Confirm alert text is incorrect");

        Logger.Info("Step 6: Accept confirm alert");

        AlertHelper.AcceptAlert();

        Assert.That(
            AlertHelper.IsAlertPresent(),
            Is.False,
            "Confirm alert was not closed after clicking OK");

        Assert.That(
            alertsPage.GetConfirmResult(),
            Is.EqualTo(testData.ConfirmResult),
            "Confirm result text is incorrect");

        Logger.Info("Step 7: Click prompt button");

        alertsPage.ClickPromptButton();

        Assert.That(
            AlertHelper.GetAlertText(),
            Is.EqualTo(testData.PromptText),
            "Prompt alert text is incorrect");

        Logger.Info("Step 8: Enter random text and accept prompt");

        var randomText = RandomDataGenerator.GenerateText();

        AlertHelper.SendKeysAlert(randomText);
        AlertHelper.AcceptAlert();

        Assert.That(
            AlertHelper.IsAlertPresent(),
            Is.False,
            "Prompt alert was not closed after clicking OK");

        Assert.That(
            alertsPage.GetPromptResult(),
            Does.Contain(randomText),
            "Prompt result does not contain the entered text");
    }
}