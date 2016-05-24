using System;
using NLog;

namespace DachsCashAPI.Utils
{
    /// <summary>
    /// Logger implementation. Work as a wrapper around NLog
    /// </summary>
    public class Logger : NLog.Logger, ILogger
    {
        private const string LoggerName = "LoggerService";
        private static NLog.Logger _logger;

        public Logger()
        {
            _logger = LogManager.GetLogger(LoggerName);
        }

        public new void Debug(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Debug, exception, format, args);
            _logger.Log(logEvent);
        }

        public new void Debug(string format, params object[] args)
        {
            Debug(null, format, args);
        }

        public new void Info(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Info, exception, format, args);
            _logger.Log(logEvent);
        }

        public new void Info(string format, params object[] args)
        {
            Info(null, format, args);
        }

        public new void Warn(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Warn, exception, format, args);
            _logger.Log(logEvent);
        }

        public new void Warn(string format, params object[] args)
        {
            Warn(null, format, args);
        }

        public new void Error(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Error, exception, format, args);
            _logger.Log(logEvent);
        }

        public new void Error(string format, params object[] args)
        {
            Error(null, format, args);
        }

        public new void Fatal(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            var logEvent = GetLogEvent(LoggerName, LogLevel.Fatal, exception, format, args);
            _logger.Log(logEvent);
        }

        public new void Fatal(string format, params object[] args)
        {
            Fatal(null, format, args);
        }

        private static LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            var assemblyProp = string.Empty;
            var classProp = string.Empty;
            var methodProp = string.Empty;
            var messageProp = string.Empty;
            var innerMessageProp = string.Empty;

            var logEvent = new LogEventInfo(level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                if (exception.TargetSite.DeclaringType != null) classProp = exception.TargetSite.DeclaringType.FullName;
                methodProp = exception.TargetSite.Name;
                messageProp = exception.Message;

                if (exception.InnerException != null) innerMessageProp = exception.InnerException.Message;
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }
    }
}