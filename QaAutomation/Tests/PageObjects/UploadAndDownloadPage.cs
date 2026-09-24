using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    public class UploadAndDownloadPage : PageWithMenu
    {
        private readonly Button downloadButton = new(By.Id("downloadButton"), "Download button");
        private readonly FileInput uploadInput = new(By.Id("uploadFile"), "Upload file");
        private readonly Label uploadedFilePathLabel = new(By.Id("uploadedFilePath"), "uploaded File Path");

        public UploadAndDownloadPage() : base(By.Id("downloadButton"), "Upload and download page")
        {
        }

        public void DownloadFile()
        {
            downloadButton.Click();
        }

        public void UploadFile(string filePath)
        {
            uploadInput.UploadFile(filePath);
        }

        public string GetUploadedFilePath()
        {
            return uploadedFilePathLabel.GetText();
        }
    }
}
