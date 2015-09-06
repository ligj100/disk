using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace disk.Core.Log
{
    /// <summary>
    /// 内置日志代理实现类
    /// </summary>
    public class Log4netLogger : IDiskLogger
    {
        private ILog logger = null;

        public Log4netLogger(ILog log)
        {
            this.logger = log;
        }

        public bool IsDebugEnabled
        {
            get { return logger.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return logger.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        public void Debug(object message)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(message);
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(message, exception);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(format, args);
            }
        }

        public void DebugFormat(string format, object args)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(format, args);
            }
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(provider, format, args);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(format, arg0, arg1);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(format, arg0, arg1, arg2);
            }
        }

        public void Error(object message)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(message);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(message, exception);
            }
        }

        public void ErrorFormat(string format, object arg0)
        {
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(format, arg0);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(format, args);
            }
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(provider, format, args);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(format, arg0, arg1);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(format, arg0, arg1, arg2);
            }
        }

        public void Fatal(object message)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(message);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(message, exception);
            }
        }

        public void FatalFormat(string format, object arg0)
        {
            if (logger.IsFatalEnabled)
            {
                logger.FatalFormat(format, arg0);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (logger.IsFatalEnabled)
            {
                logger.FatalFormat(format, args);
            }
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (logger.IsFatalEnabled)
            {
                logger.FatalFormat(provider, format, args);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            if (logger.IsFatalEnabled)
            {
                logger.FatalFormat(format, arg0, arg1);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (logger.IsFatalEnabled)
            {
                logger.FatalFormat(format, arg0, arg1, arg2);
            }
        }

        public void Info(object message)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info(message);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info(message, exception);
            }
        }

        public void InfoFormat(string format, object arg0)
        {
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(format, arg0);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(format, args);
            }
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(provider, format, args);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(format, arg0, arg1);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(format, arg0, arg1);
            }
        }

        public void Warn(object message)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(message);
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(message, exception);
            }
        }

        public void WarnFormat(string format, object arg0)
        {
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, arg0);
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, args);
            }
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, args);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, arg1);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, arg0);
            }
        }
    }
}
