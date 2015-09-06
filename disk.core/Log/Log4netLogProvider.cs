using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Core;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System.IO;

namespace disk.Core.Log
{
    /// <summary>
    /// 内置日志提供类(使用log4net)
    /// </summary>
    public class Log4netLogProvider : IDiskLogProvider
    {
        public Log4netLogProvider()
        {

        }

        public IDiskLogger GetLogger(string name)
        {
            ILog logger = log4net.LogManager.GetLogger(name);
            return new Log4netLogger(logger);
        }

        public IDiskLogger GetLogger(Type type)
        {
            ILog logger = log4net.LogManager.GetLogger(type);
            return new Log4netLogger(logger);
        }

        //public IGisquestLogger GetLogger(string name, string subDirName)
        //{
        //    ILog logger = log4net.LogManager.GetLogger(name);
        //    ChangeLog4netLogFileName(logger, subDirName);
        //    return new Log4netLogger(logger);
        //}

        //public IGisquestLogger GetLogger(Type type, string subDirName)
        //{
        //    ILog logger = log4net.LogManager.GetLogger(type);
        //    ChangeLog4netLogFileName(logger, subDirName);
        //    return new Log4netLogger(logger);
        //}

        //private void ChangeLog4netLogFileName(ILog iLog, string subDirName)
        //{
        //    LogImpl logImpl = iLog as LogImpl;
        //    if (logImpl != null)
        //    {
        //        Logger logger = (Logger)logImpl.Logger;
        //        AppenderCollection ac = logger.Appenders.Count > 0 ? logger.Appenders : logger.Hierarchy.Root.Appenders;

        //        foreach (IAppender appender in ac)
        //        {
        //            // 这里我只对RollingFileAppender类型做修改 
        //            if (appender is RollingFileAppender)
        //            {
        //                RollingFileAppender fa = (RollingFileAppender)appender;
         
        //                string sourceFile = fa.File;
        //                string fileName = Path.GetFileName(sourceFile);
        //                string directory = Path.GetDirectoryName(Path.GetDirectoryName(sourceFile) + Path.DirectorySeparatorChar + subDirName + Path.DirectorySeparatorChar);
        //                if (!sourceFile.ToLower().EndsWith(String.Concat(Path.DirectorySeparatorChar, subDirName.ToLower(), Path.DirectorySeparatorChar, fileName.ToLower())))
        //                {
        //                    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        //                    fa.File = String.Concat(directory, Path.DirectorySeparatorChar, fileName);
        //                    fa.Writer = new StreamWriter(fa.File, fa.AppendToFile, fa.Encoding);
        //                    File.Delete(sourceFile);
        //                }
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
