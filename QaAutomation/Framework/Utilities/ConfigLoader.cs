using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Framework.Utilities
{
    public static class ConfigLoader
    {
        public static ConfigurationData Load(string path)
        {
            Logger.Info($"Loading configuration from: {path}");

            var options = new JsonSerializerOptions();
            options.Converters.Add(new ObjectToInferredTypesConverter());

            var config = JsonSerializer.Deserialize<ConfigurationData>(File.ReadAllText(path), options)
                ?? throw new InvalidOperationException($"Failed to deserialize configuration from: {path}");

            return config;
        }
    }
}
