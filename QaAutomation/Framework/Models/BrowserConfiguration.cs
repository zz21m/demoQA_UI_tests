using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    public class BrowserConfiguration
    {
        public required bool Incognito { get; set; }
        public required List<string> Arguments { get; set; }
        public required Dictionary<string, object> Preferences { get; set; }
        public string DownloadBehavior { get; set; }

    }
}
