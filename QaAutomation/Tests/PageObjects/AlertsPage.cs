using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace Tests.PageObjects;

public class AlertsPage : PageWithMenu
{
    private readonly Button alertButton = new (By.Id("alertButton"), "Alert button");
    private readonly Button confirmButton = new (By.Id("confirmButton"), "Confirm button");
    private readonly Label confirmResult = new (By.Id("confirmResult"), "Confirm result");
    private readonly Button promptButton = new (By.Id("promtButton"), "Prompt button");
    private readonly Label promptResult = new (By.Id("promptResult"), "Prompt result");

    public AlertsPage() : base(By.XPath("//*[contains(@id,'AlertsWrapper')]"), "Alerts page")
    {
    }

    public void ClickAlertButton()
    {
        alertButton.Click();
    }

    public void ClickConfirmButton()
    {
        confirmButton.Click();
    }

    public void ClickPromptButton()
    {
        promptButton.Click();
    }

    public string GetConfirmResult()
    {
        return confirmResult.GetText();
    }

    public string GetPromptResult()
    {
        return promptResult.GetText();
    }
}