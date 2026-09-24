using Framework.Managers;
using Framework.Tests;
using Framework.Utilities;
using Tests.Managers;
using Tests.PageObjects;

namespace Tests;

public class FilesTest : BaseTest
{
    [Test]
    public void Files()
    {
        var testData = TestDataManager.GetInstance().TestData.Files;

        Logger.Info("Step 1: Open main page");

        var mainPage = new MainPage();

        Assert.That(
            mainPage.IsOpened(),
            Is.True,
            "Main page is not opened");

        Logger.Info("Step 2: Open Upload and Download form");

        mainPage.OpenCategoryPage(testData.CategoryPage);

        var EmptyCategoryPage = new EmptyCategoryPage();

        EmptyCategoryPage.Menu.SelectItem(testData.Category);

        var uploadAndDownloadPage = new UploadAndDownloadPage();

        Assert.That(
            uploadAndDownloadPage.IsOpened(),
            Is.True,
            "Upload And Download form is not opened");

        Logger.Info("Step 3: Download file and wait for download to complete");

        FileUtility.ClearDirectory(FileUtility.GetPath(ConfigManager.Config.DownloadDirectory));

        uploadAndDownloadPage.DownloadFile();

        var downloadedFile = FileUtility.WaitForDownloadedFile(FileUtility.GetPath(ConfigManager.Config.DownloadDirectory));

        Assert.That(
            File.Exists(downloadedFile),
            Is.True,
            "File was not downloaded");

        Logger.Info("Step 4: Upload downloaded file and verify file name");

        uploadAndDownloadPage.UploadFile(downloadedFile);

        var uploadedFilePath = uploadAndDownloadPage.GetUploadedFilePath();

        Assert.That(
            uploadedFilePath,
            Does.Contain(Path.GetFileName(downloadedFile)),
            "Uploaded file path does not contain downloaded file name");
    }
}