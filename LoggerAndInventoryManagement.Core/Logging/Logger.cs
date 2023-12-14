using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerAndInventoryManagement.Core.Logging
{
    public enum LogLevelEnum
    {
        INFO,
        DEBUG,
        WARN,
        ERROR,
        FATAL
    }

    public static class Logger
    {
        public static void LogMessage(String fileName,String message, LogLevelEnum logLevel)
        {

        }
    }
}
