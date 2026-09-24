using Framework.Browser;
using Framework.Page;
using OpenQA.Selenium;

namespace Tests.PageObjects;

public class FramesPage : PageWithMenu
{
    private readonly By upperFrameLocator = By.Id("frame1");
    private readonly By lowerFrameLocator = By.Id("frame2");
    private readonly By frameTextLocator = By.Id("sampleHeading");

    public FramesPage() : base(By.XPath("//*[contains(@id,'framesWrapper')]//*[text()='Frames']"), "Frames page")
    {
    }

    public string GetUpperFrameText()
    {
        return GetTextFromFrame(upperFrameLocator);
    }

    public string GetLowerFrameText()
    {
        return GetTextFromFrame(lowerFrameLocator);
    }

    private string GetTextFromFrame(By frameLocator)
    {
        FrameHelper.SwitchToFrame(frameLocator);

        try
        {
            return WaitHelper.WaitForNonEmptyText(frameTextLocator);
        }
        finally
        {
            FrameHelper.SwitchToDefaultContent();
        }
    }
}