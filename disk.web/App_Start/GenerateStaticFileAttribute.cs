using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using disk.Core.Log;

namespace disk.web
{
    /// <summary>
    /// 静态文件生成类
    /// 使用方法，在需要生成静态文件的Action上添加属性[GenerateStaticFileAttribute]即可
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,Inherited = true,AllowMultiple = true)]
    public class GenerateStaticFileAttribute:ActionFilterAttribute
    {

        #region 属性
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private int _Expiration = 72;
        /// <summary>
        /// 过期时间，以小时为单位
        /// </summary>
        public int Expiration {
            get { return _Expiration; }
            set { _Expiration = value; }
        }

        private string _Extension = "html";

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string Extension {
            get { return _Extension; }
            set { _Extension = value; }
        }

        /// <summary>
        /// 静态文件保存目录
        /// </summary>
        public string HtmlDirectory { get; set; }

        /// <summary>
        /// 保存的文件名
        /// </summary>
        public string FileName { get; set; }
        #endregion

        #region 构造函数

        public GenerateStaticFileAttribute()
        {
            HtmlDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Html");
        }

        #endregion

        #region Method

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var fileInfo = GetFileInfo(filterContext);
            if ((fileInfo.Exists && fileInfo.CreationTime.AddHours(Expiration) < DateTime.Now) || !fileInfo.Exists)
            {
                var deleted = false;
                var created = false;
                try
                {
                    if(fileInfo.Exists)fileInfo.Delete();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    logger.Warn(ex);
                }

                try
                {
                    if(!fileInfo.Directory.Exists)fileInfo.Directory.Create();
                    created = true;
                }
                catch (Exception ex)
                {
                    logger.Warn(ex);
                }

                if (deleted && created)
                {
                    try
                    {
                        var viewResult = filterContext.Result as ViewResult;
                        if (null != viewResult)
                        {
                            using (
                                FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Create,
                                    FileAccess.Write, FileShare.None))
                            {
                                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                                {
                                    var viewContext = new ViewContext(filterContext.Controller.ControllerContext,viewResult.View, viewResult.ViewData,viewResult.TempData,streamWriter);
                                    viewResult.View.Render(viewContext,streamWriter);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 生成文件Key
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        protected virtual string GenerateKey(ControllerContext controllerContext)
        {
            var url = controllerContext.HttpContext.Request.Url.ToString();
            if (string.IsNullOrWhiteSpace(url)) return null;

            var algorithm = HashAlgorithm.Create("SHA1");
            var data = algorithm.ComputeHash(Encoding.Unicode.GetBytes(url));
            //var key = Convert.ToBase64String(data, Base64FormattingOptions.None);
            
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            StringBuilder sbstr = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                sbstr.Append(data[i].ToString("X2"));
                //pwd = pwd + s[i].ToString("X");
            }
            return sbstr.ToString();
        }

        /// <summary>
        /// 获取静态文件信息
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        protected virtual FileInfo GetFileInfo(ControllerContext controllerContext)
        {
            var fileName = string.Empty;
            if (string.IsNullOrWhiteSpace(FileName))
            {
                var key = GenerateKey(controllerContext);
                if (string.IsNullOrWhiteSpace(key))
                {
                    key = Guid.NewGuid().ToString("N");
                }
                fileName = Path.Combine(HtmlDirectory,
                        string.IsNullOrWhiteSpace(Extension) ? key : string.Format("{0}.{1}", key, Extension));
            }
            else
            {
                fileName = Path.Combine(HtmlDirectory, FileName);
            }
            return new FileInfo(fileName);
        }

        #endregion
    }
}