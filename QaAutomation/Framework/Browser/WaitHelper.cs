using Framework.Drivers;
using Framework.Managers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Browser;

public static class WaitHelper
{
    private static WebDriverWait CreateWait(int? pollingIntervalMs = null)
    {
        var wait = new WebDriverWait(
            DriverManager.Driver,
            TimeSpan.FromSeconds(ConfigManager.Config.Timeout));

        wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

        if (pollingIntervalMs.HasValue)
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalMs.Value);
        }

        return wait;
    }

    public static IWebElement WaitForPresentElement(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);
            return elements.Count == 0 ? null : elements[0];
        });
    }

    public static IWebElement WaitForVisibleElement(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);

            if (elements.Count == 0)
            {
                return null;
            }

            var element = elements[0];

            return element.Displayed ? element : null;
        });
    }

    public static IWebElement WaitForClickableElement(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);

            if (elements.Count == 0)
            {
                return null;
            }

            var element = elements[0];

            return element.Displayed && element.Enabled ? element : null;
        });
    }

    public static IReadOnlyCollection<IWebElement> WaitForVisibleElements(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var elements = driver
                .FindElements(locator)
                .Where(element => element.Displayed)
                .ToList();

            return elements.Count > 0 ? elements : null;
        });
    }

    public static bool WaitUntilNotPresent(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver => driver.FindElements(locator).Count == 0);
    }

    public static string WaitForNonEmptyText(By locator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);

            if (elements.Count == 0)
            {
                return null;
            }

            var text = elements[0].Text;

            return string.IsNullOrEmpty(text) ? null : text;
        });
    }

    public static void WaitUntilElementStopsMoving(IWebElement element)
    {
        var wait = CreateWait(ConfigManager.Config.MovementPollingIntervalMs);

        var previousY = -1;

        wait.Until(_ =>
        {
            var currentY = element.Location.Y;

            if (currentY == previousY)
            {
                return true;
            }

            previousY = currentY;
            return false;
        });
    }

    public static void WaitUntil(Func<IWebDriver, bool> condition)
    {
        var wait = CreateWait(ConfigManager.Config.DefaultPollingIntervalMs);

        wait.Until(condition);
    }

    public static string WaitUntilNewWindowAppears(IReadOnlyCollection<string> handlesBefore)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
            driver.WindowHandles.Except(handlesBefore).SingleOrDefault());
    }

    public static IReadOnlyCollection<IWebElement> WaitForVisibleChildElements(By parentLocator, By childLocator)
    {
        var wait = CreateWait();

        return wait.Until(driver =>
        {
            var parents = driver.FindElements(parentLocator);

            if (parents.Count == 0)
            {
                return null;
            }

            var children = parents[0]
                .FindElements(childLocator)
                .Where(element => element.Displayed)
                .ToList();

            return children.Count > 0 ? children : null;
        });
    }
}