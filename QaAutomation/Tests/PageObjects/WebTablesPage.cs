using Framework.Elements;
using Framework.Models;
using Framework.Page;
using OpenQA.Selenium;
using Tests.TestData.Model;

namespace Tests.PageObjects;

public class WebTablesPage : PageWithMenu
{
    private const string DeleteAction = "Delete";

    private readonly Button addButton = new(By.Id("addNewRecordButton"), "Add button");
    private readonly WebTable table = new(By.TagName("table"), "Web table", By.XPath(".//thead//tr//th"), By.XPath(".//tbody//tr"));

    public WebTablesPage()
        : base(By.XPath("//*[@class='container-fluid']//*[text()='Web Tables']"), "Web tables page")
    {
    }

    public void AddRecord()
    {
        addButton.Click();
    }

    public bool ContainsRecord(User user)
    {
        return GetRecords().Any(record => RecordMatchesUser(record, user));
    }

    public int GetRecordCount()
    {
        return GetRecords().Count;
    }

    public void DeleteRecord(User user)
    {
        var records = GetRecords();
        var index = records.ToList().FindIndex(record => RecordMatchesUser(record, user));

        if (index == -1)
        {
            throw new InvalidOperationException(
                $"User '{user.FirstName} {user.LastName}' was not found in the Web Table");
        }

        table.ClickRowAction(index, DeleteAction);
    }

    private IReadOnlyList<User> GetRecords()
    {
        return table.GetRecords(ToUser);
    }

    private static User ToUser(IReadOnlyDictionary<string, string> values)
    {
        return new User
        {
            FirstName = values["First Name"],
            LastName = values["Last Name"],
            Age = int.Parse(values["Age"]),
            Email = values["Email"],
            Salary = int.Parse(values["Salary"]),
            Department = values["Department"]
        };
    }

    private static bool RecordMatchesUser(User record, User user)
    {
        return record.FirstName == user.FirstName
            && record.LastName == user.LastName
            && record.Age == user.Age
            && record.Email == user.Email
            && record.Salary == user.Salary
            && record.Department == user.Department;
    }
}