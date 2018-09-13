using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Infrastructure
{
    public class Log : ILog
    {
        private readonly Logger logger = null;
        private readonly IAppConfig appConfig;
        public Log(IAppConfig appConfig)
        {
            this.appConfig = appConfig;

            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            var logDir = appConfig.GetLogFolderPath();
            fileTarget.FileName = logDir+"/Logs/${shortdate}.log";
            fileTarget.Layout = "${date}\t${level:uppercase=true}\t${message}";
            fileTarget.ConcurrentWrites = true;

            fileTarget.ArchiveOldFileOnStartup = true;
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.MaxArchiveFiles = 10;
            fileTarget.EnableArchiveFileCompression = true;

            var rule1 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule1);

            if (Environment.UserInteractive)
            {
                var debugTarget = new DebuggerTarget
                {
                    Layout = "${date}\t${level:uppercase=true}\t${message}"
                };

                var rule2 = new LoggingRule("*", LogLevel.Debug, debugTarget);
                config.LoggingRules.Add(rule2);

                var consoleTarget = new ColoredConsoleTarget
                {
                    Layout = "${date}\t${level:uppercase=true}\t${message}"
                };
                var rule3 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
                config.LoggingRules.Add(rule3);
            }

            LogManager.Configuration = config;

            logger = LogManager.GetLogger("AppLog");
        }

        public void Debug(string str)
        {
            if (appConfig.LogDebug)
                logger.Debug(str);
        }

        public void Info(string str)
        {
            if (appConfig.LogInfo)
                logger.Info(str);
        }

        public void Warn(string str)
        {
            if (appConfig.LogWarn)
                logger.Warn(str);
        }

        public void Error(string str)
        {
            if (appConfig.LogError)
                logger.Error(str);
        }

        public void Error(Exception ex, string str = "")
        {
            if (appConfig.LogError)
                logger.Error($"{str} Exception - {ex.RecursivelyGetExceptionMessage()}");
        }

        public void Fatal(string str)
        {
            logger.Fatal(str);
        }
    }
}