using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    public class ConfigurationData
    {
        public required string Browser { get; set; }
        public required string BaseUrl { get; set; }
        public required int Timeout { get; set; }
        public required bool Maximize { get; set; }
        public int DefaultPollingIntervalMs { get; set; }
        public int MovementPollingIntervalMs { get; set; }
        public required string DownloadDirectory { get; set; }
        public required Dictionary<string, BrowserConfiguration> Browsers { get; set; }
    }
}
