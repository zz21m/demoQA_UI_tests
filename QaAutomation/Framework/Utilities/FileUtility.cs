using Framework.Browser;
using Framework.Drivers;
using Framework.Managers;
using OpenQA.Selenium.Support.UI;

namespace Framework.Utilities;

public static class FileUtility
{
    public static string GetPath(string directory)
    {
        var path = Path.Combine(AppContext.BaseDirectory, directory);

        Directory.CreateDirectory(path);

        return path;
    }

    public static void ClearDirectory(string directory)
    {
        Logger.Info($"Clear download directory: {directory}");

        foreach (var file in Directory.GetFiles(directory))
        {
            File.Delete(file);
        }
    }

    public static string WaitForDownloadedFile(string directory)
    {
        Logger.Info($"Wait for downloaded file in: {directory}");

        var wait = new WebDriverWait(
            DriverManager.Driver,
            TimeSpan.FromSeconds(ConfigManager.Config.Timeout));

        return wait.Until(_ =>
            Directory.GetFiles(directory)
            .FirstOrDefault(file =>
            !file.EndsWith(".crdownload") &&
            !file.EndsWith(".part")));
    }
}