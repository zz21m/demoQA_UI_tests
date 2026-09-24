using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using Tests.PageObjects;

namespace Tests;

public class MainPage : BasePage
{
    public MainPage() : base(By.ClassName("category-cards"), "Main Page")
    {
    }

    private By GetCategoryLocator(string name)
    {
        return By.XPath($"//*[@class='card-body']//*[text()='{name}']");
    }

    public void OpenCategoryPage(string name)
    {
        new Button(GetCategoryLocator(name), $"button {name}").Click();
    }
}
