using System;

namespace DachsCashAPI.Utils
{
    /// <summary>
    /// ILogger contract
    /// </summary>
    public interface ILogger
    {
        void Debug (Exception exception, String format, params object[] args);
        void Debug (String format, params object[] args);
        void Info (Exception exception, String format, params object[] args);
        void Info (String format, params object[] args);
        void Warn (Exception exception, String format, params object[] args);
        void Warn (String format, params object[] args);
        void Error (Exception exception, String format, params object[] args);
        void Error (String format, params object[] args);
        void Fatal(Exception exception, String format, params object[] args);
        void Fatal(String format, params object[] args);
    }
}