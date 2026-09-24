using Framework.Browser;
using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.Elements;

public class WebTable : BaseElement
{
    private readonly By headerLocator;
    private readonly By rowLocator;

    public WebTable(By locator, string name, By headerLocator, By rowLocator)
        : base(locator, name)
    {
        this.headerLocator = headerLocator;
        this.rowLocator = rowLocator;
    }

    public IReadOnlyList<T> GetRecords<T>(Func<IReadOnlyDictionary<string, string>, T> mapRow)
    {
        Logger.Info($"Get records from table: {Name}");

        var headers = GetHeaders();
        var rows = WaitHelper.WaitForVisibleChildElements(Locator, rowLocator);

        return rows
            .Select(row => mapRow(GetRowValues(row, headers)))
            .ToList();
    }

    public void ClickRowAction(int rowIndex, string actionTitle)
    {
        Logger.Info($"Click '{actionTitle}' action in row {rowIndex} of table: {Name}");

        var rows = WaitHelper.WaitForVisibleChildElements(Locator, rowLocator);
        var row = rows.ElementAt(rowIndex);

        var button = row
            .FindElements(By.XPath($".//*[@title='{actionTitle}']"))
            .FirstOrDefault()
            ?? throw new InvalidOperationException(
                $"Action '{actionTitle}' not found in row {rowIndex} of table '{Name}'");

        button.Click();
    }

    private IReadOnlyList<string> GetHeaders()
    {
        var headerElements = WaitHelper.WaitForVisibleChildElements(Locator, headerLocator);
        return headerElements.Select(header => header.Text).ToList();
    }

    private static IReadOnlyDictionary<string, string> GetRowValues(IWebElement row, IReadOnlyList<string> headers)
    {
        var cells = row.FindElements(By.TagName("td"))
            .Select(cell => cell.Text)
            .ToList();

        return headers
            .Zip(cells, (header, value) => (header, value))
            .ToDictionary(pair => pair.header, pair => pair.value);
    }
}