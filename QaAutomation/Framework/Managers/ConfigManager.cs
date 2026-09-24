using Framework.Drivers;
using Framework.Models;
using Framework.Utilities;
using System.Text.Json;

namespace Framework.Managers;

public sealed class ConfigManager
{
    private const string ConfigFolder = "Config";
    private const string ConfigFileName = "ConfigurationData.json";

    private static ConfigurationData? _config;

    public static ConfigurationData Config
    {
        get
        {
            if (_config == null)
            {
                var path = Path.Combine(AppContext.BaseDirectory, ConfigFolder, ConfigFileName);
                _config = ConfigLoader.Load(path);
            }

            return _config;
        }
    }
}