using Framework.Utilities;
using Tests.TestData;
using Tests.TestData.Model;

namespace Tests.Managers;

public sealed class TestDataManager
{
    private const string TestDataFolder = "TestData";
    private const string TestDataFileName = "TestData.json";

    private static TestDataManager? _instance;
    private readonly TestDataModel _testData;
    public TestDataModel TestData
    {
        get
        {
            return _testData;
        }
    }

    private TestDataManager()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            TestDataFolder,
            TestDataFileName);

        Logger.Info($"Loading test data from: {path}");

        _testData = JsonDeserializer.Deserialize<TestDataModel>(path);
    }

    public static TestDataManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TestDataManager();
        }

        return _instance;
    }
}