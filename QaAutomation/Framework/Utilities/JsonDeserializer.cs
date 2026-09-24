using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Framework.Utilities
{
    public static class JsonDeserializer
    {
        public static T Deserialize<T>(string path)
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(path));
        }
    }   
}
