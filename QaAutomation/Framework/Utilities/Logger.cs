using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utilities
{
    public static class Logger
    {
        private static readonly NLog.Logger Log = LogManager.GetCurrentClassLogger();
        public static void Info(string message)
        {
            Log.Info(message);
        }
    }
}
