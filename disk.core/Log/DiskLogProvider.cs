using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace disk.Core.Log
{
    /// <summary>
    /// 日志使用提供类
    /// private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger("ServiceSession");
    /// </summary>
    public class DiskLogProvider
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        private static IDiskLogProvider provider = null;
        /// <summary>
        /// 锁
        /// </summary>
        private static object lockObj = new Object();

        /// <summary>
        /// 获取日志实例
        /// </summary>
        public static IDiskLogProvider LogInstance
        {
            get
            {
                if (provider == null)
                {
                    /*
                    LogConfigSection section = LogConfigSection.GetConfig();
                    lock (lockObj)
                    {
                        if (provider == null)
                        {
                            if (section == null)
                            {
                                //没有配置，或配置无效则默认使用内置的log4net日志
                                provider = new Log4netLogProvider();
                            }
                            else
                            {
                                Type cacheType = Type.GetType(section.provider, false);
                                if (cacheType == null) throw new Exception(String.Format("Failed to build LogProvider, type of {0}.", section.provider));
                                provider = Activator.CreateInstance(cacheType) as IDiskLogProvider;
                            }
                        }
                    }*/
                    provider = new Log4netLogProvider();
                }
                return provider;
            }
        }
    }
}
