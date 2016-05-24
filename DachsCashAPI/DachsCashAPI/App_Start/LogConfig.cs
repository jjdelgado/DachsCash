using NLog;
using NLog.Config;
using NLog.Targets;

namespace DachsCashAPI.App_Start
{
    public class LogConfig
    {
        public static void Register()
        {
            const string layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";

            var config = new LoggingConfiguration();
            
            var consoleTarget = new ColoredConsoleTarget();
            consoleTarget.Layout = layout;
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            fileTarget.FileName = "${basedir}/logs/log.txt";
            fileTarget.Layout = layout;
            config.AddTarget("file", fileTarget);

            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            LogManager.Configuration = config;

            new LogFactory();
        }
    }
}