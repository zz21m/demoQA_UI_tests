using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class FileInput : BaseElement
    {
        public FileInput(By locator, string name) : base(locator, name)
        {
        }

        public void UploadFile(string filePath)
        {
            Logger.Info($"Upload file: {Path.GetFileName(filePath)}");
            Find().SendKeys(filePath);
        }
    }
}