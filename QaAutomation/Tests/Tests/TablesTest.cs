using Framework.Tests;
using NUnit.Framework;
using Tests.Forms;
using Tests.PageObjects;
using Tests.TestData.Model;
using Tests.TestData;
using Framework.Utilities;

namespace Tests;

public class TablesTest : BaseTest
{
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetTablesData))]
    public void Tables(TablesTDModel testData)
    {
        var mainPage = new MainPage();

        Logger.Info("Step 1: Open main page");

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Web Tables form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var webTablesPage = new WebTablesPage();

        Assert.That(
            webTablesPage.IsOpened(),
            Is.True,
            "Web tables form is not opened");

        Logger.Info("Step 3: Open Registration Form");

        webTablesPage.AddRecord();

        var registrationForm = new RegistrationForm();

        Assert.That(
            registrationForm.IsOpened(),
            Is.True,
            "Registration form is not opened");

        Logger.Info("Step 4: Add user to the table");

        registrationForm.FillUser(testData.User);
        registrationForm.Submit();

        Assert.That(
            registrationForm.IsClosed(),
            Is.True,
            "Registration form is not closed");

        Assert.That(
            webTablesPage.ContainsRecord(testData.User),
            Is.True,
            "User was not added to the table");

        Logger.Info("Step 5: Delete user from the table");

        var recordsBeforeDelete = webTablesPage.GetRecordCount();

        webTablesPage.DeleteRecord(testData.User);

        var recordsAfterDelete = webTablesPage.GetRecordCount();

        Assert.That(
            recordsAfterDelete,
            Is.EqualTo(recordsBeforeDelete - 1),
            "Number of records did not change");

        Assert.That(
            webTablesPage.ContainsRecord(testData.User),
            Is.False,
            "User was not deleted from the table");
    }
}