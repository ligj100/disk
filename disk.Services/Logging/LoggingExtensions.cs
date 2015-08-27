using System;
using disk.Core.Domain.Members;
using disk.Core.Domain.Logging;

namespace disk.Services.Logging
{
    public static class LoggingExtensions
    {
        public static void Debug(this ILogger logger, string message, Exception exception = null, Member Member = null)
        {
            FilteredLog(logger, LogLevel.Debug, message, exception, Member);
        }
        public static void Information(this ILogger logger, string message, Exception exception = null, Member Member = null)
        {
            FilteredLog(logger, LogLevel.Information, message, exception, Member);
        }
        public static void Warning(this ILogger logger, string message, Exception exception = null, Member Member = null)
        {
            FilteredLog(logger, LogLevel.Warning, message, exception, Member);
        }
        public static void Error(this ILogger logger, string message, Exception exception = null, Member Member = null)
        {
            FilteredLog(logger, LogLevel.Error, message, exception, Member);
        }
        public static void Fatal(this ILogger logger, string message, Exception exception = null, Member Member = null)
        {
            FilteredLog(logger, LogLevel.Fatal, message, exception, Member);
        }

        private static void FilteredLog(ILogger logger, LogLevel level, string message, Exception exception = null, Member Member = null)
        {
            //don't log thread abort exception
            if ((exception != null) && (exception is System.Threading.ThreadAbortException))
                return;

            if (logger.IsEnabled(level))
            {
                string fullMessage = exception == null ? string.Empty : exception.ToString();
                logger.InsertLog(level, message, fullMessage, Member);
            }
        }
    }
}
