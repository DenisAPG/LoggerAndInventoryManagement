using LoggerAndInventoryManagement.Core.Logging;
using System.Data;

namespace LoggerAndInventoryManagement.Tests.LoggerTests
{
    [TestClass]
    public class LoggerUnitTests
    {

        [TestInitialize] public void TestInitialize() 
        {
            
        }   

        [TestMethod]
        public void LogMessage_ValidParameters_SuccessfullLogging()
        {
            var fileName = "LogMessage_ValidParameters_SuccessfullLogging.log";
            var logMessage = "Validating a Successful Info Message";
            var lastLine = "";
            Logger.LogMessage(fileName, "Validating a Successful InfoMessage",LogLevelEnum.INFO);
            Assert.IsTrue(File.Exists(fileName), "File does not exist!");
            lastLine = File.ReadAllLines(fileName).Last();
            Assert.IsTrue(lastLine.Contains(logMessage), "Log message was not properly written!");
        }

        [TestMethod]
        public void LogMessage_FileNameDoesntExist_SuccessfullLogging()
        {
            string fileName = "LogMessage_FileNameDoesntExist_SuccessfullLogging.log";
            var logMessage = "Validating a Successful Info Message";
            var lastLine = "";
            if (File.Exists(fileName))
                File.Delete(fileName);
            Logger.LogMessage(fileName, "Validating a Successful InfoMessage", LogLevelEnum.INFO);
            Assert.IsTrue(File.Exists(fileName), "File does not exist!");
            lastLine = File.ReadAllLines(fileName).Last();
            Assert.IsTrue(lastLine.Contains(logMessage), "Log message was not properly written!");
        }

        [TestMethod]
        public void LogMessage_FileAlreadyOpen_SuccessfullLogging()
        {
            string fileName = "LogMessage_FileAlreadyOpen_SuccessfullLogging.log";
            var logMessage = "Validating a Successful Info Message";
            var lastLine = "";
            if (File.Exists(fileName))
                File.Delete(fileName);
            Logger.LogMessage(fileName, "Validating a Successful InfoMessage", LogLevelEnum.INFO);
            Assert.IsTrue(File.Exists(fileName), "File does not exist!");
            lastLine = File.ReadAllLines(fileName).Last();
            Assert.IsTrue(lastLine.Contains(logMessage), "Log message was not properly written!");
        }

        [TestMethod]
        public void LogMessage_FileIsReadOnly_UnauthorizedAccessException()
        {
            string fileName = "LogMessage_FileIsReadOnly_UnauthorizedAccessException.log";
            var logMessage = "Validating a Successful Info Message";
            Assert.ThrowsException<UnauthorizedAccessException>(() => Logger.LogMessage(fileName, logMessage, LogLevelEnum.INFO));
        }

        [TestMethod]
        public void LogMessage_InvalidFilePath_ThrowsAnException()
        {
            string fileName = "LogMessage_InvalidFilePath_ThrowsAnException.log";
            var logMessage = "Validating a Successful Info Message";
            Assert.ThrowsException<DirectoryNotFoundException>(() => Logger.LogMessage(fileName, logMessage, LogLevelEnum.INFO));
        }

        [TestMethod]
        public void LogMessage_EmptyFileName_ThrowsAnException()
        {
            string fileName = "LogMessage_EmptyFileName_ThrowsAnException.log";
            var logMessage = "Validating a Successful Info Message";
            Assert.ThrowsException<ArgumentException>(() => Logger.LogMessage(fileName, logMessage, LogLevelEnum.INFO));
        }

        [TestMethod]
        public void LogMessage_NullFileName_ThrowsAnException()
        {
            string fileName = "LogMessage_NullFileName_ThrowsAnException.log";
            var logMessage = "Validating a Successful Info Message";
            Assert.ThrowsException<ArgumentNullException>(() => Logger.LogMessage(fileName, logMessage, LogLevelEnum.INFO));
        }

        [TestMethod]
        public void LogMessage_ConcurrentLogFileAccess_SuccessfullyLogging()
        {
            int numberOfThreads = 2;
            string fileName = "LogMessage_ConcurrentLogFileAccess_SuccessfullyLogging.log";
            var logMessage = "Validating a Successful Info Message - Thread ";
            Parallel.For(0, numberOfThreads, (i) => Logger.LogMessage(fileName, logMessage + i + " Message", LogLevelEnum.INFO));
            Assert.IsTrue(File.Exists(fileName), "File does not exist!");
            var allLines= File.ReadAllLines(fileName);
            List<String> lastLines = [allLines[allLines.Length - 1], allLines[allLines.Length - 2]];
            Assert.IsTrue(lastLines.Exists(x => x.Contains(logMessage + "1 Message")));
            Assert.IsTrue(lastLines.Exists(x => x.Contains(logMessage + "1 Message")));
        }


        [TestMethod]
        [DataRow("DEBUG")]
        [DataRow("INFO")]
        [DataRow("WARN")]
        [DataRow("ERROR")]
        [DataRow("FATAL")]
        public void LogMessage_LogLevelEnumDebug_SucessfullyLoggingBasedOnLogLevel(string enumAsString)
        {
            var fileName = "LogMessage_LogLevelEnumDebug_SucessfullyLoggingDebug.log";
            var logMessage = "Validating a Successful Info Message";
            var lastLine = "";
            LogLevelEnum logEnum = (LogLevelEnum)Enum.Parse(typeof(LogLevelEnum), enumAsString); 
            Logger.LogMessage(fileName, "Validating a Successful InfoMessage", logEnum);
            Assert.IsTrue(File.Exists(fileName), "File does not exist!");
            lastLine = File.ReadAllLines(fileName).Last();
            Assert.IsTrue(lastLine.Contains(logMessage), "Log message was not properly written!");
        }
    }
}