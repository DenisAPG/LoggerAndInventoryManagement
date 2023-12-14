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

        private static string LogFormat = "[{0}] {1} {2}";

        private static object lockObject = new object();

        public static void LogMessage(String fileName,String message, LogLevelEnum logLevel)
        {
            lock (lockObject) { 
                if (String.IsNullOrWhiteSpace(fileName))
                    throw new ArgumentNullException("A File name is expected to log new messages");

                int lastDirectoryIndex = fileName.LastIndexOf(@"\");

                if (lastDirectoryIndex > -1)
                {
                    string filePath = fileName.Substring(0, fileName.Length - 1);
                    if (!Directory.Exists(filePath))
                        throw new DirectoryNotFoundException();
                }

                if (new FileInfo(fileName).IsReadOnly && File.Exists(fileName))
                    throw new UnauthorizedAccessException();

                using (StreamWriter sw = new StreamWriter(fileName, true,Encoding.UTF8))
                {
                    sw.WriteLine(String.Format(LogFormat, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logLevel, message));
                }
            }
        }
    }
}
