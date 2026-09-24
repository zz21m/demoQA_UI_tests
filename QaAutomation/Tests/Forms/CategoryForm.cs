using Framework.Elements;
using Framework.Page;
using Framework.Utilities;
using OpenQA.Selenium;

namespace Tests.Forms;

public class CategoryForm : BasePage
{
    public CategoryForm() : base(By.ClassName("left-pannel"), "Category form")
    {
    }

    private By GetCategoryLocator(string categoryName)
    {
        return By.XPath($"//*[@class='header-wrapper']//*[text()='{categoryName}']");
    }

    private By GetItemLocator(string itemName)
    {
        return By.XPath($"//*[@class='menu-list']//*[text()='{itemName}']");
    }

    public void SelectCategory(string categoryName)
    {
        new Button(GetCategoryLocator(categoryName), $"Category {categoryName}").Click();
    }

    public void SelectItem(string itemName)
    {
        new Button(GetItemLocator(itemName), $"Menu item {itemName}").Click();
    }
}