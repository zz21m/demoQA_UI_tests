using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Elements;

public class Select : BaseElement
{
    public Select(By locator, string name)
        : base(locator, name)
    {
    }

    public void SelectByValue(string value)
    {
        Logger.Info($"Select value '{value}' in element: {Name}");     
        new SelectElement(Find()).SelectByValue(value);
    }
}