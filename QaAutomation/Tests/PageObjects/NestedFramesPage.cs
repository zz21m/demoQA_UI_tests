using Framework.Browser;
using OpenQA.Selenium;
using Tests.PageObjects;

public class NestedFramesPage : PageWithMenu
{
    private readonly By parentFrameLocator = By.Id("frame1");
    private readonly By childFrameLocator = By.TagName("iframe");
    private readonly By frameBodyLocator = By.TagName("body");

    public NestedFramesPage()
        : base(By.XPath("//*[@id='framesWrapper']//*[text()='Nested Frames']"), "Nested frames page")
    {
    }

    public string GetParentFrameText()
    {
        FrameHelper.SwitchToFrame(parentFrameLocator);

        try
        {
            return WaitHelper.WaitForNonEmptyText(frameBodyLocator);
        }
        finally
        {
            FrameHelper.SwitchToDefaultContent();
        }
    }

    public string GetChildFrameText()
    {
        FrameHelper.SwitchToFrame(parentFrameLocator);
        FrameHelper.SwitchToFrame(childFrameLocator);

        try
        {
            return WaitHelper.WaitForNonEmptyText(frameBodyLocator);
        }
        finally
        {
            FrameHelper.SwitchToDefaultContent();
        }
    }
}